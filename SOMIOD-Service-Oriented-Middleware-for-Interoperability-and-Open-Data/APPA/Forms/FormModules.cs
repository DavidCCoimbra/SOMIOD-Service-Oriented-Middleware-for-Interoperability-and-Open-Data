using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace APPA.Forms
{
    public partial class FormModules : Form
    {
        public FormModules()
        {
            InitializeComponent();
        }

        private void btnAllApplications_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }   

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a query string parameter
            string xml = "<Module><res_type>module</res_type></Module>";
            string encodedXml = HttpUtility.UrlEncode(xml);
            string url = $"http://localhost:52990/api/somiod/applications/{textApplication.Text}/modules?xml={encodedXml}";

            // Send the GET request and retrieve the response as a string
            string xmlString = client.DownloadString(url);

            if (xmlString == "<Modules />")
            {
                MessageBox.Show("There are no modules in this application currently");
                return;
            }

            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            // Store the data in a DataSet and DataTable
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new XmlNodeReader(doc));
            DataTable dataTable = dataSet.Tables[0];

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;

        }

        private void btnGetApplication_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }
            if (textApplicationPut.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a query string parameter
            string xml = "<Module><res_type>module</res_type></Module>";
            string encodedXml = HttpUtility.UrlEncode(xml);
            string url = $"http://localhost:52990/api/somiod/applications/{textApplication.Text}/modules/{textApplicationPut.Text}?xml={encodedXml}";

            // Send the GET request and retrieve the response as a string
            string xmlString = client.DownloadString(url);

            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            // Create a DataTable with columns for the data and subscription fields
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Module Name", typeof(string));
            dataTable.Columns.Add("Module CreationDT", typeof(string));
            dataTable.Columns.Add("Data ID", typeof(string));
            dataTable.Columns.Add("Data Name", typeof(string));
            dataTable.Columns.Add("Data CreationDT", typeof(string));
            dataTable.Columns.Add("Subscription ID", typeof(string));
            dataTable.Columns.Add("Subscription Name", typeof(string));
            dataTable.Columns.Add("Subscription EventType", typeof(string));
            dataTable.Columns.Add("Subscription Event", typeof(string));
            dataTable.Columns.Add("Subscription CreationDT", typeof(string));

            XmlNode moduleNode = doc.SelectSingleNode("Module");
            string moduleName = moduleNode.SelectSingleNode("@name").InnerText;
            string moduleCreationDT = moduleNode.SelectSingleNode("@creation_dt").InnerText;

            MessageBox.Show(moduleName);
            
            // Add rows to the DataTable for each of the modules in the application

                string dataID = "";
                string dataName = "";
                string dataCreationDT = "";
                string subscriptionID = "";
                string subscriptionName = "";
                string subscriptionEvent = "";
                string subscriptionEventType = "";
                string subscriptionCreationDT = "";

                List<XmlNode> nodes = new List<XmlNode>();

                foreach (XmlNode data in doc.SelectNodes("//Data"))
                { 
                    MessageBox.Show(data.InnerText);
                    nodes.Add(data);
                }

                foreach (XmlNode subscription in doc.SelectNodes("//Subscription"))
                {
                    nodes.Add(subscription);
                }

                foreach (XmlNode node in nodes)
                {
                    if (node.Name == "Data")
                    {

                        dataID = node.SelectSingleNode("@id").InnerText;
                        MessageBox.Show(dataID);
                        dataName = node.SelectSingleNode("@content").InnerText;
                        dataCreationDT = node.SelectSingleNode("@creation_dt").InnerText;
                    }
                    else if (node.Name == "Subscription")
                    {
                        //subscriptionID = node.SelectSingleNode("@id").InnerText;
                        subscriptionName = node.SelectSingleNode("@name").InnerText;
                        subscriptionEventType = node.SelectSingleNode("@endpoint").InnerText;
                        subscriptionEvent = node.SelectSingleNode("@event").InnerText;
                        subscriptionCreationDT = node.SelectSingleNode("@creation_dt").InnerText;
                    }

                    dataTable.Rows.Add(moduleName, moduleCreationDT, dataID, dataName, dataCreationDT, subscriptionID, subscriptionName, subscriptionEventType, subscriptionEvent, subscriptionCreationDT);
                }
                dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }
            if (textApplicationPut.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Module name='" + textApplicationPut.Text + "'><res_type>module</res_type></Module>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text + "/modules", "POST", xml);

            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            // Store the data in a DataSet and DataTable
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new XmlNodeReader(doc));
            DataTable dataTable = dataSet.Tables[0];

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;
        }

        private void btnUpdateApplication_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }
            if (textApplicationPut.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Insert new module name");
                return;
            }
            
            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Module name='" + textBox1.Text + "'><res_type>module</res_type></Module>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text + "/modules/" + textApplicationPut.Text, "PUT", xml);

            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            // Store the data in a DataSet and DataTable
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new XmlNodeReader(doc));
            DataTable dataTable = dataSet.Tables[0];

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;
        }

        private void textApplication_TextChanged(object sender, EventArgs e)
        {

        }

        private void textApplicationPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }
            if (textApplicationPut.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Module> <res_type>module</res_type> </Module>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text + "/modules/" + textApplicationPut.Text, "DELETE", xml);

            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            // Store the data in a DataSet and DataTable
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new XmlNodeReader(doc));
            DataTable dataTable = dataSet.Tables[0];

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;
        }
    }
}
