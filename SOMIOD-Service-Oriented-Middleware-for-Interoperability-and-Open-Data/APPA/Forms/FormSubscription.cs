using System;
using System.Data;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace APPA.Forms
{
    public partial class FormSubscription : Form
    {
        bool mClientConnected = false;
        MqttClient mClientGlobal = null;

        public FormSubscription()
        {
            InitializeComponent();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormSubscription_Load(object sender, EventArgs e)
        {

        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e, string type)
        {
            // Convert the message payload to a string
            string message = Encoding.UTF8.GetString(e.Message);

            string[] messageParts = message.Split('|');
            string httpMethod = messageParts[0];
            string payload = messageParts[1];

            if (type == "Creation" && httpMethod == "POST")
            {
                
                MessageBox.Show("Received message on topic POST " + e.Topic + ": " + payload);
                return;
            }
            if (type == "Deletion" && httpMethod == "DELETE")
            {
                MessageBox.Show("Received message on topic DELETE " + e.Topic + ": " + payload);
                return;
            }
            if (type == "Both")
            {
                // Display the message to the user
                MessageBox.Show("Received message on topic BOTH " + e.Topic + ": " + payload);
            }

        } 

        private void button3_Click(object sender, EventArgs e)
        {
            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }

            if (textBoxModule.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }

            if (textSubName.Text == "")
            {
                MessageBox.Show("Insert subscription name");
                return;
            }

            if (comboBoxSubEvent.SelectedItem == null)
            {
                MessageBox.Show("Select an event type");
                return;
            }
            
            if (textBoxSubEndpoint.Text == "")
            {
                MessageBox.Show("Insert endpoint");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Subscription name='" + textSubName.Text + "' event='" + comboBoxSubEvent.SelectedItem +
                "' endpoint='"+ textBoxSubEndpoint.Text +"'><res_type>subscription</res_type></Subscription>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text + "/modules/" + textBoxModule.Text + "/subscriptions", "POST", xml);
            
            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            // Store the data in a DataSet and DataTable
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new XmlNodeReader(doc));
            DataTable dataTable = dataSet.Tables[0];

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;

            mClientGlobal = ProcessMqtt(comboBoxSubEvent.SelectedItem.ToString());
        }

        private MqttClient ProcessMqtt(string typeOperation)
        {
            MqttClient mClient = new MqttClient(textBoxSubEndpoint.Text); //endpoint 
            string[] mStrTopicsInfo = { textBoxModule.Text }; //name of the module


            // Connect to the MQTT broker
            try
            {
                mClient.Connect(Guid.NewGuid().ToString());
            }
            catch (MqttConnectionException ex)
            {
                throw new Exception("Error connecting to message broker: " + ex.Message);
            }

            // Check if the connection was successful
            if (!mClient.IsConnected)
            {
                throw new Exception("Error connecting to message broker...");
            }

            // Specify events we are interested in
            // New message arrived event
            mClient.MqttMsgPublishReceived += (s, e) => client_MqttMsgPublishReceived(s, e, typeOperation); ;

            // Subscribe to the specified topics
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }; //QoS – depends on the number of topics
            try
            {
                mClient.Subscribe(new string[] { textBoxModule.Text }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            catch (MqttCommunicationException ex)
            {
                throw new Exception("Error subscribing to topics: " + ex.Message);
            }

            mClientConnected = true;

            return mClient;
        }


        private void btnUpdateApplication_Click(object sender, EventArgs e)
        {
            string[] mStrTopicsInfo = { textBoxModule.Text }; //name of the module

            if (textApplication.Text == "")
            {
                MessageBox.Show("Insert application name");
                return;
            }

            if (textBoxModule.Text == "")
            {
                MessageBox.Show("Insert module name");
                return;
            }

            if (textSubName.Text == "")
            {
                MessageBox.Show("Insert subscription name");
                return;
            }

            // Make an HTTP request to the API
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/xml";

            // Encode the XML data as a string
            string xml = "<Subscription> <res_type>subscription</res_type> </Subscription>";

            // Send the POST request and retrieve the response as a string
            string xmlString = client.UploadString("http://localhost:52990/api/somiod/applications/" + textApplication.Text + "/modules/" + textBoxModule.Text + "/subscriptions/" + textSubName.Text, "DELETE", xml);

            // Load the XML data from the API response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            // Store the data in a DataSet and DataTable
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new XmlNodeReader(doc));
            DataTable dataTable = dataSet.Tables[0];

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;

            unsubscribeMqtt(mStrTopicsInfo);
        }

        private void unsubscribeMqtt(string[] topic)
        {
            if (mClientConnected)
            {
                try
                {
                    mClientGlobal.Unsubscribe(topic);
                }
                catch (MqttCommunicationException ex)
                {
                    throw new Exception("Error unsubscribing from topics: " + ex.Message);
                }

                // Disconnect from the MQTT broker and free resources
                try
                {
                    mClientGlobal.Disconnect();
                }
                catch (MqttCommunicationException ex)
                {
                    throw new Exception("Error disconnecting from message broker: " + ex.Message);
                }
            }
        }

        private void textApplication_TextChanged(object sender, EventArgs e)
        {

        }
    }
}