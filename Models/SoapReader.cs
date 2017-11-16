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
        static Constant _contstat;
        public SoapReader() {
            _contstat = new Constant();
        }
        private string GetHeader(XmlNode node,string nodeName)
        {
            string NodeName = node.Attributes[_contstat.Action].Value;
            return NodeName;
        }
        
        public List<SoapHeader> GetHeaders(XmlNode node)
        {
            List<SoapHeader> Headers = new List<SoapHeader>();
            string soapAction = GetHeader(node, String.Empty);
            Headers.Add(new SoapHeader() { description = String.Empty, key = _contstat.ContentType, value = _contstat.TextXML });
            Headers.Add(new SoapHeader() { description = String.Empty, key = _contstat.SOAPAction, value = soapAction });
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
           var SoapUiProject = doc.GetElementsByTagName(_contstat.SoapuiProject);
            Info.Name = SoapUiProject[0].Attributes[_contstat.Name].Value;
            Info.PostmanId = Guid.NewGuid().ToString();
            Info.Description = String.Empty;
            Info.Schema = _contstat.PostmanSchema;
            return Info;
        }

        public string GetOperatiomName(XmlNode node)
        {
            string NodeName = node.Attributes[_contstat.Name].Value;
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
            Body.mode = _contstat.Raw;
            Body.Raw = GetSoapRawBody(node);
            return Body;

        }
        private string GetSoapRawBody(XmlNode node) {
            //con:request
            node = node[_contstat.Call];
            string Body = node[_contstat.Request].InnerXml;
            Body = SoapRequestTailor(Body);

            return Body;
        }
        private string SoapRequestTailor(string Request) {

            int ends = Request.Length - _contstat.EndCharachtarsToSkip;
            Request = Request.Substring(_contstat.StartCharachtarsToSkip, ends);
            //  Replace SoapUi Newline to Postman Newline.
            Request = Request.Replace(_contstat.SoapUINewLine, _contstat.PostmanNewLine);
            return Request;

        }
        public string GetURI(XmlNode node)
        {
            //con:endpoint con:call
            node = node[_contstat.Call];
            string Endpoint = node[_contstat.Endpoint].InnerXml;
            return Endpoint;
        }
        private XmlNodeList GetListOfOperations(XmlDocument doc) {
            // To Delete.
           return doc.GetElementsByTagName(String.Empty);
        }
    }
}
