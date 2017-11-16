using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandWatch.Models
{
    class Constant
    {
        /// <summary>
        /// Gets the action namespace. 
        /// </summary>
        /// <value>The action.</value>
        public string Action { get { return "action"; } }
        /// <summary>
        /// Gets the type of the text of content type.
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType { get { return "Content-Type"; } }
        /// <summary>
        /// Gets the type of the expected content type.
        /// </summary>
        /// <value>The text XML.</value>
        public string TextXML { get { return "text/xml"; } }
        /// <summary>
        /// Gets the SOAP action.
        /// </summary>
        /// <value>The SOAP action.</value>
        public string SOAPAction { get { return "SOAPAction"; } }
        /// <summary>
        /// Gets the soapui project namespace.
        /// </summary>
        /// <value>The soapui project.</value>
        public string SoapuiProject { get { return "con:soapui-project"; } }
        /// <summary>
        /// Gets the name namespace.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get { return "name"; } }
        /// <summary>
        /// Gets the raw text.
        /// </summary>
        /// <value>The raw.</value>
        public string Raw { get { return "raw"; } }
        /// <summary>
        /// Gets the call namespace.
        /// </summary>
        /// <value>The call.</value>
        public string Call { get { return "con:call"; } }
        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <value>The request.</value>
        public string Request { get { return "con:request"; } }
        /// <summary>
        /// Gets the endpoint namespace.
        /// </summary>
        /// <value>The endpoint.</value>
        public string Endpoint { get { return "con:endpoint"; } }

        /// <summary>
        /// Gets the SOAP UI new line.
        /// </summary>
        /// <value>The SOAP UI new line.</value>
        public string SoapUINewLine { get { return "\\r\n"; } }
        /// <summary>
        /// Gets the postman new line.
        /// </summary>
        /// <value>The postman new line.</value>
        public string PostmanNewLine { get { return "\r\n"; } }

        /// <summary>
        /// Gets the operations namespace in SoapUI.
        /// </summary>
        /// <value>The operation.</value>
        public string Operation { get { return "con:operation"; } }
        public string Post { get { return "POST"; } }
        /// <summary>
        /// Gets the postman schema.
        /// </summary>
        /// <value>The postman schema.</value>
        public string PostmanSchema { get { return "https://schema.getpostman.com/json/collection/v2.0.0/collection.json"; } }

        /// <summary>
        /// Gets the saving path on the server.
        /// </summary>
        /// <value>The saving path.</value>
        public string SavingPath { get { return "C:\\Users\\abmu\\Desktop\\"; } }

        /// <summary>
        /// Gets the extention of the result file.
        /// </summary>
        /// <value>The extention.</value>
        public string Extention { get { return ".json"; } }

        /// <summary>
        /// Gets the number charachtars to skip at the start of the body string.
        /// </summary>
        /// <value>The start charachtars to skip.</value>
        public int StartCharachtarsToSkip { get { return 9; } }

        /// <summary>
        /// Gets the number charachtars to skip at the end of the body string.
        /// </summary>
        /// <value>The end charachtars to skip.</value>
        public int EndCharachtarsToSkip { get { return 12; } }


    }
}
