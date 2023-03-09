using SOMIOD.Context;
using SOMIOD.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SOMIOD.Controllers
{

    [RoutePrefix("api/somiod/applications")]
    public class ApplicationController : ApiController
    {
        
        [HttpGet]
        [Route("{applicationName}")]
        public HttpResponseMessage Get(string applicationName)
        {
            
            using (var db = new SomiodDBContext())
            {
                var response = new HttpResponseMessage();
                // Get the record with the specified ID from the database
                Application model = db.Applications.Where(a => a.name == applicationName).FirstOrDefault();
                if (model == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }

                // Find all the Module rows with the specified parent application id
                var modules = db.Modules.Where(m => m.parent == model.id);
                List<Data> datas = new List<Data>();
                List<Subscription> subscriptions = new List<Subscription>();

                foreach (var module in modules)
                {
                    using (var db2 = new SomiodDBContext())
                    {
                        // Find all the Data rows with the specified parent module id
                        var dataRows = db2.Datas.Where(d => d.parent == module.id).ToList();
                        datas.AddRange(dataRows);
                    }

                    using (var db3 = new SomiodDBContext())
                    {
                        // Find all the Subscription rows with the specified parent module id
                        var subscriptionRows = db3.Subscriptions.Where(s => s.parent == module.id).ToList();
                        subscriptions.AddRange(subscriptionRows);
                    }
                }

                // Return the data as XML
                XElement xml = CreateXmlExtended(model, modules, datas, subscriptions);

                // Prepare our Response

                response.Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
                response.StatusCode = HttpStatusCode.OK;
                response.ReasonPhrase = "All Applications";

                return response;
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            // Read the request body and parse it as needed
            XDocument doc = (XDocument)request.Properties["request_body"];
            XElement value = doc.Root;
            using (var db = new SomiodDBContext())
            {

                // Parse the XML and save the data to the database
                Application model = ParseXml(value);

                // Check if a name with the same value already exists in the database
                bool nameExists = db.Applications.Any(a => a.name == model.name);

                if (nameExists)
                {
                    // Return an error response if the name already exists
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent("A name with the same value already exists in the database"),
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "Name already exists"
                    };
                    return response;
                }
                else
                {
                    // Add the new record to the database and return a success response
                    db.Applications.Add(model);
                    db.SaveChanges();
                    var response = Get(model.name.ToString());

                    return response;
                }

            }
        }

        [HttpPut]
        [Route("{applicationName}")]
        public HttpResponseMessage Put(string applicationName, HttpRequestMessage request)
        {
            // Read the request body and parse it as needed
            XDocument doc = (XDocument)request.Properties["request_body"];
            XAttribute value = doc.Root.Attribute("name");    
            using (var db = new SomiodDBContext())
            {

                // Get the record with the specified ID from the database
                Application model = db.Applications.FirstOrDefault(a => a.name == applicationName);
                
                if (model == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Application not found");
                }

                // Check if any record with the same name exists, excluding the record being updated
                bool nameExists = db.Applications.Any(a => a.name == value.Value);              

                if (nameExists)
                {
                    // Return an error response if the name already exists
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent("A name with the same value already exists in the database"),
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "Name already exists"
                    };
                    return response;
                }
                else
                {                 
                    // Add the new record to the database and return a success response
                    model = UpdateModel(model, value);
                    db.SaveChanges();
                    var response = Get(model.name.ToString());

                    return response;
                }
            }
        }

        [HttpDelete]
        [Route("{applicationName}")]
        public HttpResponseMessage Delete(string applicationName)
        {
            using (var db = new SomiodDBContext())
            {
                var response = new HttpResponseMessage();

                // Get the record with the specified ID from the database
                Application model = db.Applications.Where(a => a.name == applicationName).FirstOrDefault();

                if (model == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }

                // Find all the Module rows with the specified parent application id
                var modules = db.Modules.Where(m => m.parent == model.id);
                List<Data> datas = new List<Data>();
                List<Subscription> subscriptions = new List<Subscription>();

                foreach (var module in modules)
                {
                    using (var db2 = new SomiodDBContext())
                    {
                        // Find all the Data rows with the specified parent module id
                        var dataRows = db2.Datas.Where(d => d.parent == module.id).ToList();
                        datas.AddRange(dataRows);
                    }

                    using (var db3 = new SomiodDBContext())
                    {
                        // Find all the Subscription rows with the specified parent module id
                        var subscriptionRows = db3.Subscriptions.Where(s => s.parent == module.id).ToList();
                        subscriptions.AddRange(subscriptionRows);
                    }
                }

                if (datas.Any())
                {
                    foreach (var data in datas)
                    {
                        db.Datas.Attach(data);
                        db.Datas.Remove(data);
                    }
                }
                db.SaveChanges();

                if (subscriptions.Any())
                {
                    // Delete all the Subscription rows
                    foreach (var subscription in subscriptions)
                    {
                        db.Subscriptions.Attach(subscription);
                        db.Subscriptions.Remove(subscription);
                    }
                }
                db.SaveChanges();

                if (modules.Any())
                {
                    foreach (var module in modules)
                    {
                        db.Modules.Attach(module);
                        db.Modules.Remove(module);
                    }
                }
                db.SaveChanges();

                // Delete the record from the database
                db.Applications.Remove(model);
                db.SaveChanges();

                // Return the data as XML
                XElement xml = CreateXmlExtended(model, modules, datas, subscriptions);

                // Prepare our Response

                response.Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
                response.StatusCode = HttpStatusCode.OK;
                response.ReasonPhrase = "All Applications";

                return response;
            }

        }


        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            using (var db = new SomiodDBContext())
            {
                // Get all the records from the database
                var models = db.Applications.ToList();

                // Return the data as XML
                XElement xml = new XElement("Applications",
                    from m in models
                    select CreateXml(m)
                );

                // Prepare our Response
                var response = new HttpResponseMessage
                {
                    Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = "All Applications"
                };
                return response;
            }
        }

        private Application ParseXml(XElement value)
        {
            // Parse the XML and create a new Application object
            Application model = new Application
            {
                name = value.Attribute("name").Value
            };
            return model;
        }

        private Application UpdateModel(Application model, XAttribute value)
        {
            // Update the Application object with the data from the XML
            model.name = value.Value;
            return model;
        }

        private XElement CreateXml(Application model)
        {
            // Create an XML element from the Application object
            XElement response = new XElement("Application",
                new XAttribute("name", model.name),
                new XAttribute("id", model.id),
                new XAttribute("creation_dt", model.creation_dt)
            );
            return response;
        }

        private XElement CreateXmlExtended(Application applicationData, IEnumerable<Module> moduleData, List<Data> data, List<Subscription> subscriptions)
        {
            // Create an XML element from the Application object
            XElement response = new XElement("Application",
                new XAttribute("name", applicationData.name),
                new XAttribute("creation_dt", applicationData.creation_dt),
                    from m in moduleData
                    select new XElement("Module",
                        new XAttribute("name", m.name),
                        new XAttribute("creation_dt", m.creation_dt),
                            from d in data
                            where d.parent == m.id
                            select new XElement("Data",
                                new XAttribute("id", d.id),
                                new XAttribute("name", d.content),
                                new XAttribute("creation_dt", d.creation_dt)),
                            from s in subscriptions
                            where s.parent == m.id
                            select new XElement("Subscription",
                                new XAttribute("id", s.id),
                                new XAttribute("name", s.name),
                                new XAttribute("event", s.event_),
                                new XAttribute("endpoint", s.endpoint),
                                new XAttribute("creation_dt", s.creation_dt))));
            return response;
        }
    }

}
