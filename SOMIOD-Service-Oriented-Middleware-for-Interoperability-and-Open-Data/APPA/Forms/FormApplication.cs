using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace APPA.Forms
{
    public partial class FormApplication : Form
    {
        public FormApplication()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { 
            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a query string parameter
            string xml = "<Application><res_type>application</res_type></Application>";
            string encodedXml = HttpUtility.UrlEncode(xml);
            string url = $"http://localhost:52990/api/somiod/applications?xml={encodedXml}";

            // Send the GET request and retrieve the response as a string
            string xmlString = client.DownloadString(url);
            if(xmlString == "<Applications />")
            {
                MessageBox.Show("There are no applications currently");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Create an application or insert one already existing");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a query string parameter
            string xml = "<Application><res_type>application</res_type></Application>";
            string encodedXml = HttpUtility.UrlEncode(xml);
            string url = $"http://localhost:52990/api/somiod/applications/{textApplication.Text}?xml={encodedXml}";

            // Send the GET request and retrieve the response as a string
            var xmlString = client.DownloadString(url);

            if (xmlString == null)
            {
                MessageBox.Show("Application " + textApplication.Text + " not found");
                return;
            }
            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);


            // Create a DataTable with columns for the data and subscription fields
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Application Name", typeof(string));
            dataTable.Columns.Add("Application CreationDT", typeof(string));
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

            XmlNode applicationNode = doc.SelectSingleNode("Application");
            string applicationName = applicationNode.SelectSingleNode("@name").InnerText;
            string applicationCreationDT = applicationNode.SelectSingleNode("@creation_dt").InnerText;

            MessageBox.Show(applicationName);

            // Add rows to the DataTable for each of the modules in the application
            foreach (XmlNode module in doc.SelectNodes("//Module"))
            {
                var moduleName = module.SelectSingleNode("@name").InnerText;
                MessageBox.Show(moduleName);
                var moduleCreationDT = module.SelectSingleNode("@creation_dt").InnerText;

                string dataID = "";
                string dataName = "";
                string dataCreationDT = "";
                string subscriptionID = "";
                string subscriptionName = "";
                string subscriptionEvent = "";
                string subscriptionEndpoint = "";
                string subscriptionCreationDT = "";

                List<XmlNode> nodes = new List<XmlNode>();

                foreach (XmlNode data in module.SelectNodes("//Module/Data"))
                {
                    MessageBox.Show(data.InnerText);
                    nodes.Add(data);
                }

                foreach (XmlNode subscription in module.SelectNodes("//Module/Subscription"))
                {
                    nodes.Add(subscription);
                }

                foreach (XmlNode node in nodes)
                {
                    if (node.Name == "Data")
                    {
                        
                        dataID = node.SelectSingleNode("@id").InnerText;
                        MessageBox.Show(dataID);
                        dataName = node.SelectSingleNode("@name").InnerText;
                        dataCreationDT = node.SelectSingleNode("@creation_dt").InnerText;
                    }
                    else if (node.Name == "Subscription")
                    {
                        subscriptionID = node.SelectSingleNode("@id").InnerText;
                        MessageBox.Show(subscriptionID);
                        subscriptionName = node.SelectSingleNode("@name").InnerText;
                        subscriptionEvent = node.SelectSingleNode("@event").InnerText;
                        subscriptionEndpoint = node.SelectSingleNode("@endpoint").InnerText;
                        subscriptionCreationDT = node.SelectSingleNode("@creation_dt").InnerText;
                    }

                    dataTable.Rows.Add(applicationName, applicationCreationDT, moduleName, moduleCreationDT, dataID, dataName, dataCreationDT, subscriptionID, subscriptionName, subscriptionEndpoint, subscriptionEvent, subscriptionCreationDT);
                }
                dataGridView1.DataSource = dataTable;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Application name='" + textApplication.Text + "'><res_type>application</res_type></Application>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications", "POST", xml);       

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
                MessageBox.Show("Insert the new name");
                return;
            }
            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Application name='" + textApplicationPut.Text + "'><res_type>application</res_type></Application>";

            // Send the PUT request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text, "PUT", xml);

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textApplication_TextChanged(object sender, EventArgs e)
        {

        }

        private void textApplicationPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Application> <res_type>application</res_type> </Application>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text, "DELETE", xml);

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
