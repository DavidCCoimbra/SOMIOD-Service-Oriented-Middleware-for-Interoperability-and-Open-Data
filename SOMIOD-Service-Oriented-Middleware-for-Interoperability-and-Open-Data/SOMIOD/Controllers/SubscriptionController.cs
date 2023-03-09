using SOMIOD.Context;
using SOMIOD.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;

namespace SOMIOD.Controllers
{
    [RoutePrefix("api/somiod/applications/{applicationName}/modules/{moduleName}/subscriptions")]
    public class SubscriptionController : ApiController
    {
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(string applicationName, string moduleName, HttpRequestMessage request)
        {
            // Read the request body and parse it as needed
            XDocument doc = (XDocument)request.Properties["request_body"];
            XElement value = doc.Root;

            using (var db = new SomiodDBContext())
            {
                // Find the Application with the specified name
                Application application = db.Applications.FirstOrDefault(a => a.name == applicationName);
                if (application == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Application not found");
                }

                // Find the Module with the specified name
                Module module = db.Modules.FirstOrDefault(a => a.name == moduleName);
                if (module == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Module not found");
                }

                // Parse the XML and save the data to the database
                Subscription subscriptionModel = ParseXml(value);

                // Check if any record with the same name exists, excluding the record being updated
                bool nameExists = db.Subscriptions.Any(a => a.name.ToString() == subscriptionModel.name);

                if (nameExists)
                {
                    // Return an error response if the name already exists
                    return new HttpResponseMessage
                    {
                        Content = new StringContent("A name with the same value already exists in the database"),
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "Name already exists"
                    }; 
                }

                subscriptionModel.parent = module.id;
                var subscriptionData = db.Subscriptions.Add(subscriptionModel);
                db.SaveChanges();

                XElement xml = CreateXml(subscriptionData);

                // Prepare our Response
                var response = new HttpResponseMessage
                {
                    Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                    StatusCode = HttpStatusCode.OK,
                };
  
                return response;
            }
        }

        [HttpDelete]
        [Route("{subscriptionName}")]
        public HttpResponseMessage Delete(string applicationName, string moduleName, string subscriptionName)
        {
            using (var db = new SomiodDBContext())
            {
                // Find the Application with the specified name
                Application application = db.Applications.FirstOrDefault(a => a.name == applicationName);
                if (application == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Application not found");
                }

                // Find the Module entity with the specified ID and parent Application
                Module moduleData = db.Modules.Where(m => m.parent == application.id).FirstOrDefault(m => m.name == moduleName);
                if (moduleData == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Module not found");
                }

                // Find all the Data rows with the specified parent module id
                var subscriptionData = db.Subscriptions.Where(s => s.parent == moduleData.id).FirstOrDefault(s => s.name == subscriptionName);

                if (subscriptionData == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Subscription not found");
                }

                db.Subscriptions.Attach(subscriptionData);
                db.Subscriptions.Remove(subscriptionData);
                
                XElement xml = CreateXml(subscriptionData);
                
                // Prepare our Response
                var response = new HttpResponseMessage
                {
                    Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                    StatusCode = HttpStatusCode.OK,
                };
                
                db.SaveChanges();

                return response;
            }

        }

        private Subscription ParseXml(XElement value)
        {
            // Parse the XML and create a new Data object
            Subscription model = new Subscription
            {
                name = value.Attribute("name").Value,
                event_ = value.Attribute("event").Value,
                endpoint = value.Attribute("endpoint").Value
            };
            return model;
        }
        
        private XElement CreateXml(Subscription model)
        {
            // Create an XML element from the Module object
            XElement response = new XElement("Subscription",
                new XAttribute("id", model.id),
                new XAttribute("name", model.name),
                new XAttribute("creation_dt", model.creation_dt),
                new XAttribute("event", model.event_),
                new XAttribute("endpoint", model.endpoint)
            );
            return response;
        }
    }
}
