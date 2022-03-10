using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Collection_Funds
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public string sTextBox;
        public Form1()
        {         
            if (!getConnection())
            {
                MessageBox.Show("אין תקשורת לשרת");
                return;
            }
            else
                MessageBox.Show("שלום");
            InitializeComponent();
            instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text.TrimStart().TrimEnd();
                string web_customer = "http://192.168.1.101:8082/api/Customer/" + id + "?sessionId=2802";
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)WebRequest.Create(web_customer).GetResponse();
                JObject jo = JObject.Parse(GetResponseBody(myHttpWebResponse));
                sTextBox = "שלום " + jo.SelectToken("firstName") + " " + jo.SelectToken("lastName");
                MessageBox.Show("שלום " + jo.SelectToken("firstName") + " " + jo.SelectToken("lastName"));
                Form2 form2 = new Form2();
                form2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("לקוח לא נמצא");
            }
        }
            // 029337524
        public static Boolean getConnection()
        {
            HttpWebRequest myHttpWebRequest = WebRequest.Create("http://192.168.1.101:8082/api/session?terminalNumber=2802") as HttpWebRequest;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            return (myHttpWebResponse.StatusCode == HttpStatusCode.OK);
        }
        public static String GetResponseBody(HttpWebResponse response)
        {
            Stream responseStream = response.GetResponseStream();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStreamReader = new StreamReader(responseStream, enc);
            return responseStreamReader.ReadToEnd();
        }

        public static implicit operator Form1(Form2 v)
        {
            throw new NotImplementedException();
        }
    }
}