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
using Module = SOMIOD.Models.Module;

namespace SOMIOD.Controllers
{
    [RoutePrefix("api/somiod/applications/{applicationName}/modules")]
    public class ModuleController : ApiController
    {
                
        [HttpGet]
        [Route("{moduleName}")]
        public HttpResponseMessage Get(string applicationName, string moduleName)
        {
            using (var db = new SomiodDBContext())
            {

                // Get Application values
                Application applicationData = db.Applications.Where(a => a.name == applicationName).FirstOrDefault();

                
                if (applicationData == null)
                {
                    // Return an error response if the name already exists
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent("This application was not found in our database"),
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = "Application Not found"
                    };
                    return response;
                }

                // Find the Module entity with the specified ID and parent Application
                Module moduleData = db.Modules.Where(m => m.parent == applicationData.id).FirstOrDefault(m => m.name.ToString() == moduleName);

                if (moduleData == null)
                {
                    // Return an error response if the name already exists
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent("This module was not found in our database"),
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = "Not found"
                    };
                    return response;
                }
                else
                {

                    // ALL Data associated to the module
                    var data = db.Datas.Where(d => d.parent == moduleData.id).ToList();

                    // ALL Subscriptions associated to the module
                    var subscriptions = db.Subscriptions.Where(d => d.parent == moduleData.id).ToList();

                    // Create the XML tree
                    XElement xml = CreateXmlExtended(moduleData, data, subscriptions);

                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                        StatusCode = HttpStatusCode.OK,
                        ReasonPhrase = "All Applications"
                    };
                    return response;
                }

            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(string applicationName, HttpRequestMessage request)
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

                // Parse the XML and save the data to the database
                Module model = ParseXml(value);

                // Check if a name with the same value already exists in the database
                bool nameExists = db.Modules.Any(a => a.name == model.name);

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
                    // Set the parent property of the Module entity to the ID of the Application
                    model.parent = application.id;

                    // Add the new record to the database and return a success response
                    db.Modules.Add(model);
                    db.SaveChanges();
                    var response = Get(applicationName, model.name.ToString());

                    return response;
                }
            }
        }

        [HttpPut]
        [Route("{moduleName}")]
        // Update a specific Module entity for a specific Application
        public HttpResponseMessage Put(string applicationName, string moduleName, HttpRequestMessage request)
        {
            // Read the request body and parse it as needed
            XDocument doc = (XDocument)request.Properties["request_body"];
            XAttribute value = doc.Root.Attribute("name");

            using (var db = new SomiodDBContext())
            {
                // Find the Application with the specified name
                Application application = db.Applications.FirstOrDefault(a => a.name == applicationName);
                if (application == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Application not found");
                }

                // Find the Module entity with the specified ID and parent Application
                Module module = db.Modules.Where(m => m.parent == application.id).FirstOrDefault(m => m.name == moduleName);

                if (module == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Module not found");
                }

                // Check if any record with the same name exists, excluding the record being updated
                bool nameExists = db.Modules.Any(a => a.name.ToString() == value.Value);

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
                else {

                    module = UpdateModel(module, value);
                    db.SaveChanges();
                    var response = Get(applicationName, module.name.ToString());
                    return response;

                }  
            }
        }

        [HttpDelete]
        [Route("{moduleName}")]
        // Delete a specific Module entity for a specific Application
        public HttpResponseMessage Delete(string applicationName, string moduleName)
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
                var dataData = db.Datas.Where(d => d.parent == moduleData.id).ToList();

                // Find all the Subscription rows with the specified parent module id
                var subscriptionData = db.Subscriptions.Where(d => d.parent == moduleData.id).ToList();

                if (dataData.Any())
                {
                    foreach (var data in dataData)
                    {
                        db.Datas.Attach(data);
                        db.Datas.Remove(data);
                    }
                }
                db.SaveChanges();

                if (subscriptionData.Any())
                {
                    // Delete all the Subscription rows
                    foreach (var subscription in subscriptionData)
                    {
                        db.Subscriptions.Attach(subscription);
                        db.Subscriptions.Remove(subscription);
                    }
                }
                db.SaveChanges();

                db.Modules.Remove(moduleData);
                db.SaveChanges();

                // Return the data as XML
                XElement xml = CreateXmlExtended(moduleData, dataData, subscriptionData);

                // Prepare our Response
                var response = new HttpResponseMessage()
                {
                    Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = "All Applications",
                };

                return response;
            }
        }

        
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll(string applicationName)
        {
            using (var db = new SomiodDBContext())
            {
                // Get Application values
                Application applicationData = db.Applications.Where(a => a.name == applicationName).FirstOrDefault();


                if (applicationData == null)
                {
                    // Return an error response if the name already exists
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent("This application was not found in our database"),
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = "Application Not found"
                    };
                    return response;
                }

                // Find the Module entity with the specified ID and parent Application
                // IEnumerable<Module> modulesData
                var modulesData = db.Modules.Where(m => m.parent == applicationData.id).ToList();

                if (modulesData == null)
                {
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent("This Modules was not found in our database"),
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = "Modules Not found"
                    };
                    return response;
                }
                else
                {
                    // Return the data as XML
                    XElement xml = new XElement("Modules",
                        from m in modulesData
                        select CreateXml(m)
                    );

                    // Prepare our Response
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                        StatusCode = HttpStatusCode.OK,
                        ReasonPhrase = "All Modules from Application"
                    };
                    return response;
                }
            }
        }
        
        private Module ParseXml(XElement value)
            {
            // Parse the XML and create a new Module object
            Module model = new Module
            {
                name = value.Attribute("name").Value
            };
            return model;
            }
        
        private Module UpdateModel(Module model, XAttribute value)
        {
            // Update the Module object with the data from the XML
            model.name = value.Value;
            return model;
        }

        private XElement CreateXml(Module model)
        {
            // Create an XML element from the Module object
            XElement response = new XElement("Module",
                new XAttribute("name", model.name),
                new XAttribute("id", model.id),
                new XAttribute("creation_dt", model.creation_dt)
            );
            return response;
        }

        private XElement CreateXmlExtended(Module moduleData, IEnumerable<Data> data, IEnumerable<Subscription> subscriptions)
        {
            // Create an XML element from the Module object
            XElement response = new XElement("Module",
                        new XAttribute("name", moduleData.name),
                        new XAttribute("creation_dt", moduleData.creation_dt),
                            from d in data
                            select new XElement("Data",
                                new XAttribute("id", d.id),
                                new XAttribute("content", d.content),
                                new XAttribute("creation_dt", d.creation_dt)),
                            from s in subscriptions
                            select new XElement("Subscription",               
                                new XAttribute("name", s.name),
                                new XAttribute("event", s.event_),
                                new XAttribute("endpoint", s.endpoint),
                                new XAttribute("creation_dt", s.creation_dt))
            );
            return response;
        }

    }
}
