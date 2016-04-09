using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("Accounts.xml");

            //MessageBox.Show(doc.SelectSingleNode("Accounts/Account/Name").InnerText);
            XmlNodeList accountNodes = doc.SelectNodes("books/book");

            

            foreach (XmlNode node in accountNodes)
            {
                MessageBox.Show(node.SelectSingleNode("title").InnerText);
            }

        }
    }
}
