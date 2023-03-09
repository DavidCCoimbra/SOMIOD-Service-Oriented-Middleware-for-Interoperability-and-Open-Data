using SOMIOD.Controllers;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace SOMIOD
{
    public class CustomHttpControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;
        public CustomHttpControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            XDocument doc = new XDocument();

            string resType = "";
            if (request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == "xml").Value != null)
            {
                // Get the query string parameter "xml" from the current request
                string xml = request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == "xml").Value;

                // Decode the XML data from the query string parameter
                string decodedXml = HttpUtility.UrlDecode(xml);

                // Load the XML data from the query string parameter into an XDocument
                doc = XDocument.Parse(decodedXml);
                resType = doc.Root.Element("res_type").Value;
            }
            else
            {
                // Get the route data for the current request
                doc = XDocument.Load(request.Content.ReadAsStreamAsync().Result);
                // Retrieve the values from the request body
                if (doc.Root.Attribute("res_type") != null)
                {
                    resType = doc.Root.Attribute("res_type").Value;
                } else
                {
                    resType = doc.Root.Element("res_type").Value;
                }
            }
            // Load the schema and the XML document
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string schemaFilePath = Path.Combine(baseDirectory, "SOMIOD.xsd");
            XmlReader schemaReader = XmlReader.Create(schemaFilePath);
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, schemaReader); 
            
            // Validate the XML document against the schema
            bool isValid = true;
            doc.Validate(schemaSet, (sender, e) => {
                isValid = false;
            });

            // If the document is not valid, return an error response
            if (!isValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, "The XML document is not valid");
            }

            // Store the values from the request body in the request's Properties collection
            request.Properties["res_type"] = resType;
            request.Properties["request_body"] = doc;

            // Get the configuration file.
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            // Get the connectionStrings section.
            ConnectionStringsSection section = (ConnectionStringsSection)config.GetSection("connectionStrings");

            // Modify the connection string.
            section.ConnectionStrings["SomiodDatabaseConnection"].ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\SomiodDatabase.mdf") + ";Integrated Security=True";

            // Save the changes.
            config.Save();

            // Based on the value of the "action" parameter, redirect the request to the appropriate controller
            switch (resType)
            {
                case "application":
                    return new HttpControllerDescriptor(_configuration, "ApplicationController", typeof(ApplicationController));
                case "module":
                    return new HttpControllerDescriptor(_configuration, "ModuleController", typeof(ModuleController));
                case "data":
                    return new HttpControllerDescriptor(_configuration, "DataController", typeof(DataController));
                case "subscription":
                    return new HttpControllerDescriptor(_configuration, "SubscriptionController", typeof(SubscriptionController));
                default:
                    return base.SelectController(request);
            }
        }
    }
}
