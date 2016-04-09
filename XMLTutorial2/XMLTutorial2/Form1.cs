﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLTutorial2
{
    public partial class Form1 : Form
    {

        XmlDocument doc = new XmlDocument();
        XmlNodeList accountNodes;

        XmlNodeList accountNodesPrime;

        public Form1()
        {

            InitializeComponent();

            doc.Load("Accounts.xml");

            accountNodes = doc.SelectNodes("books/book");

            //accountNodesPrime = ((XmlElement)doc.GetElementsByTagName("books")[0]).GetElementsByTagName("book");

            foreach (XmlNode node in accountNodes)
            {
                //string id = node.Attributes["id"].Value;

                try {
                    //MessageBox.Show(node.SelectSingleNode("title").InnerText);
                }
                catch 
                {

                    //throw new Exception("You piece of shit");
                }
            }


            //foreach (XmlElement element in accountNodesPrime)
            //{
                //string isbn = element.GetAttribute("ISBN");

                //XmlElement testElement = element.GetElementsByTagName("price")[0] as XmlElement;

                //MessageBox.Show(isbn);
            //}

            // Book element
            XmlElement bookElement = doc.CreateElement("book");
            bookElement.SetAttribute("genre", "novel");
            bookElement.SetAttribute("ISBN", "1-861001-57-10");
            bookElement.SetAttribute("publicationdata", "1823-01-01");

            // Book title and price elements
            XmlElement titleElement = doc.CreateElement("title");
            XmlElement priceElement = doc.CreateElement("price");
            priceElement.InnerText = "20";
            titleElement.InnerText = "1 billion dollars";

            // Append title and price to book element
            bookElement.AppendChild(titleElement);
            bookElement.AppendChild(priceElement);

            // Append new book to books parent element
            doc.SelectSingleNode("books").AppendChild(bookElement);

            
            // Delete pride and prejudice
            foreach (XmlNode node in accountNodes)
            {
                if(node.SelectSingleNode("title").InnerText == "1 billion dollars")
                {
                    // get element document from which the node exists, get the root element from which the node sits, and remove this particular node
                    node.OwnerDocument.DocumentElement.RemoveChild(node);
                }
            }



            doc.Save("Accounts.xml");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
