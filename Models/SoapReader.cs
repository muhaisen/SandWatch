using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SandWatch.Models
{
    /// <summary>
    /// Class SoapReader.
    /// </summary>
    /// <seealso cref="SandWatch.Models.ISoapReader" />
    class SoapReader : ISoapReader
    {
        /// <summary>
        /// The contstat object to get all the text constants.
        /// </summary>
        private Constant _contstat;
        /// <summary>
        /// Initializes a new instance of the <see cref="SoapReader"/> class.
        /// </summary>
        public SoapReader() {
            _contstat = new Constant();
        }
        /// <summary>
        /// Gets header from XML node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>System.String.</returns>
        private string GetHeader(XmlNode node,string nodeName)
        {
            string NodeName = node.Attributes[nodeName].Value;
            return NodeName;
        }

        /// <summary>
        /// Gets the static headers for the SOAP call.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>List&lt;SoapHeader&gt;.</returns>
        public List<SoapHeader> GetHeaders(XmlNode node)
        {
            List<SoapHeader> Headers = new List<SoapHeader>();
            string soapAction = GetHeader(node, _contstat.Action);
            Headers.Add(new SoapHeader() { description = String.Empty, key = _contstat.ContentType, value = _contstat.TextXML });
            Headers.Add(new SoapHeader() { description = String.Empty, key = _contstat.SOAPAction, value = soapAction });
            return Headers;
        }

        /// <summary>
        /// Gets the information about the SOAPUI project metadata.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <returns>SoapUiInfo.</returns>
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

        /// <summary>
        /// Gets the name of the operation from a given XmlNode.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.String.</returns>
        public string GetOperationName(XmlNode node)
        {
            string NodeName = node.Attributes[_contstat.Name].Value;
            return NodeName;

        }


        /// <summary>
        /// Gets the SOAP body node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>SoapBody.</returns>
        public SoapBody GetSoapBody(XmlNode node)
        {
            SoapBody Body = new SoapBody();
            Body.mode = _contstat.Raw;
            Body.Raw = GetSoapRawBody(node);
            return Body;

        }
        /// <summary>
        /// Gets the SOAP raw body.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.String.</returns>
        private string GetSoapRawBody(XmlNode node) {
            //con:request
            node = node[_contstat.Call];
            string Body = node[_contstat.Request].InnerXml;
            Body = SoapRequestTailor(Body);

            return Body;
        }
        /// <summary>
        /// Adjust the SOAP body as valid XML to be used in Postman.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <returns>System.String.</returns>
        private string SoapRequestTailor(string Request) {

            int ends = Request.Length - _contstat.EndCharachtarsToSkip;
            Request = Request.Substring(_contstat.StartCharachtarsToSkip, ends);
            //  Replace SoapUi Newline to Postman Newline.
            Request = Request.Replace(_contstat.SoapUINewLine, _contstat.PostmanNewLine);
            return Request;

        }
        /// <summary>
        /// Gets the Endpoint URI.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.String.</returns>
        public string GetURI(XmlNode node)
        {
            //con:endpoint con:call
            node = node[_contstat.Call];
            string Endpoint = node[_contstat.Endpoint].InnerXml;
            return Endpoint;
        }

        /// <summary>
        /// Gets all operations from the raw SOAPUI prject file.
        /// </summary>
        /// <param name="Doc">The document.</param>
        /// <returns>XmlNodeList.</returns>
        public XmlNodeList GetAllOperations(XmlDocument Doc)
        {
          return Doc.GetElementsByTagName(_contstat.Operation);
        }
    }
}
