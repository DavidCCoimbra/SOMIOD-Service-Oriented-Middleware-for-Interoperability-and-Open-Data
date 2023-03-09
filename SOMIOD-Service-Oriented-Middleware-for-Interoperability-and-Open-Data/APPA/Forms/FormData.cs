using System;
using System.Data;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Exceptions;

namespace APPA.Forms
{
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        private void textApplicationPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGetApplication_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }
            
            if (textApplicationModule.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }

            if (textData.Text == "")
            {
                MessageBox.Show("Insert content");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Data content='" + textData.Text + "'><res_type>data</res_type></Data>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text + "/modules/" + textApplicationModule.Text + "/data", "POST", xml);

            MqttClient mcClient = new MqttClient("127.0.0.1", 1883, false, null, null, MqttSslProtocols.None);
            string[] mStrTopicsInfo = { textApplicationModule.Text };

            // Connect to the MQTT broker
            try
            {
                mcClient.Connect(Guid.NewGuid().ToString());
            }
            catch (MqttConnectionException ex)
            {
                throw new Exception("Error connecting to message broker: " + ex.Message);
            }

            // Check if the connection was successful
            if (!mcClient.IsConnected)
            {
                throw new Exception("Error connecting to message broker...");
            }

            // Publish the message
            try
            {
                mcClient.Publish(textApplicationModule.Text, Encoding.UTF8.GetBytes("POST|" + textData.Text));
            }
            catch (MqttCommunicationException ex)
            {
                throw new Exception("Error publishing message: " + ex.Message);
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

        private void textApplication_TextChanged(object sender, EventArgs e)
        {

        }

        private void textData_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }

            if (textApplicationModule.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }

            if (textDataID.Text == "")
            {
                MessageBox.Show("Insert data id");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Data><res_type>data</res_type></Data>";

            // Send the Delete request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text + "/modules/" + textApplicationModule.Text + "/data/" + Convert.ToInt32(textDataID.Text), "DELETE", xml);

            MqttClient mcClient = new MqttClient("127.0.0.1", 1883, false, null, null, MqttSslProtocols.None);
            string[] mStrTopicsInfo = { textApplicationModule.Text };

            // Connect to the MQTT broker
            try
            {
                mcClient.Connect(Guid.NewGuid().ToString());
            }
            catch (MqttConnectionException ex)
            {
                throw new Exception("Error connecting to message broker: " + ex.Message);
            }

            // Check if the connection was successful
            if (!mcClient.IsConnected)
            {
                throw new Exception("Error connecting to message broker...");
            }

            // Publish the message
            try
            {
                mcClient.Publish(textApplicationModule.Text, Encoding.UTF8.GetBytes("DELETE|" + textDataID.Text));
            }
            catch (MqttCommunicationException ex)
            {
                throw new Exception("Error publishing message: " + ex.Message);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}