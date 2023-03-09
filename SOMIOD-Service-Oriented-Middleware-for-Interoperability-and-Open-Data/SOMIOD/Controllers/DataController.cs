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
    [RoutePrefix("api/somiod/applications/{applicationName}/modules/{moduleName}/data")]
    public class DataController : ApiController
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
                Application application= db.Applications.FirstOrDefault(a => a.name == applicationName);
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
                Data dataModel = ParseXml(value);
                
                dataModel.parent = module.id;
                var dataData = db.Datas.Add(dataModel);
                db.SaveChanges();

                XElement xml = CreateXml(dataData);

                var response = new HttpResponseMessage
                {
                    Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                    StatusCode = HttpStatusCode.OK,
                };

                return response;
            }
        }

        [HttpDelete]
        [Route("{dataId}")]
        public HttpResponseMessage Delete(string applicationName, string moduleName, int dataId)
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
                var dataData = db.Datas.FirstOrDefault(d => d.id == dataId);

                if (dataData != null)
                {          
                    db.Datas.Attach(dataData);
                    db.Datas.Remove(dataData);    
                }
                db.SaveChanges();

                XElement xml = CreateXml(dataData);

                var response = new HttpResponseMessage
                {
                    Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml"),
                    StatusCode = HttpStatusCode.OK,
                };

                return response;
            }

        }


        private Data ParseXml(XElement value)
        {
            // Parse the XML and create a new Data object
            Data model = new Data
            {
                content = value.Attribute("content").Value
            };
            return model;
        }

        private XElement CreateXml(Data model)
        {
            // Create an XML element from the Module object
            XElement response = new XElement("Data",
                new XAttribute("id", model.id),
                new XAttribute("content", model.content),
                new XAttribute("creation_dt", model.creation_dt)
            );
            return response;
        }

    }
}
