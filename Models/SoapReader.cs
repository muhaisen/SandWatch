using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SandWatch.Models
{
    class SoapReader : ISoapReader
    {
        private string GetHeader(XmlNode node,string nodeName)
        {
            string NodeName = node.Attributes["action"].Value;
            return NodeName;
        }
        
        public List<SoapHeaders> GetHeaders(XmlNode node)
        {
            List<SoapHeaders> Headers = new List<SoapHeaders>();
            string soapAction = GetHeader(node,"");
            Headers.Add(new SoapHeaders() { description = "", key = "Content-Type", value = "text/xml" });
            Headers.Add(new SoapHeaders() { description = "", key = "SOAPAction", value = soapAction });
            return Headers;
        }

        public List<string> GetHost(XmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public SoapUiInfo GetInfo(XmlDocument doc)
        {
            SoapUiInfo Info = new SoapUiInfo();
            //con:soapui-project
           var SoapUiProject = doc.GetElementsByTagName("con:soapui-project");
            Info.Name = SoapUiProject[0].Attributes["name"].Value;
            Info.PostmanId = Guid.NewGuid().ToString();
            Info.Description = "";
            Info.Schema = "https://schema.getpostman.com/json/collection/v2.0.0/collection.json";
            return Info;
        }

        public string GetOperatiomName(XmlNode node)
        {
            string NodeName = node.Attributes["name"].Value;
            return NodeName;

        }

        public List<string> GetPath(XmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public List<string> GetQuery(XmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public SoapBody GetSoapBody(XmlNode node)
        {
            SoapBody Body = new SoapBody();
            Body.mode = "raw";
            Body.Raw = GetSoapRawBody(node);
            return Body;

        }
        private string GetSoapRawBody(XmlNode node) {
            //con:request
            node = node["con:call"];
            string Body = node["con:request"].InnerXml;
            Body = SoapRequestTailor(Body);

            return Body;
        }
        private string SoapRequestTailor(string Request) {

            int ends = Request.Length - 12;
            Request = Request.Substring(9, ends);
            Request = Request.Replace("\\r", "\\r\\n");
            //System.Diagnostics.Debug.WriteLine(Request);
            return Request;

        }
        public string GetURI(XmlNode node)
        {
            //con:endpoint con:call
            node = node["con:call"];
            string Endpoint = node["con:endpoint"].InnerXml;
            return Endpoint;
        }
        private XmlNodeList GetListOfOperations(XmlDocument doc) {
            // To Delete.
           return doc.GetElementsByTagName("");
        }
    }
}
