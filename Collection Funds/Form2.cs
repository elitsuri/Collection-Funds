using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Collection_Funds
{
    public partial class Form2 : Form
    {
        public Label label; 
        public Form2()
        {
            InitializeComponent();
            label1.Text = Form1.instance.sTextBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {      
            string web_customer = "http://URL/api/basket/addItem";
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)WebRequest.Create(web_customer).GetResponse();
            JObject jo = JObject.Parse(GetResponseBody(myHttpWebResponse));
        }
        // 029337524
        private string GetResponseBody(HttpWebResponse myHttpWebResponse)
        {
            throw new NotImplementedException();
        }
    }
}
