using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SandWatch.Models
{
    /// <summary>
    /// Interface ISoapReader
    /// </summary>
    interface ISoapReader
    {
        /// <summary>
        /// Gets the information about the SOAPUI project metadata..
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <returns>SoapUiInfo.</returns>
        SoapUiInfo GetInfo(XmlDocument doc);
        /// <summary>
        /// Gets the name of the operation from a given XmlNode.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.String.</returns>
        string GetOperationName(XmlNode node);
        /// <summary>
        /// Gets the Endpoint URI.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.String.</returns>
        string GetURI(XmlNode node);
        /// <summary>
        /// Gets the static headers for the SOAP call.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>List&lt;SoapHeader&gt;.</returns>
        List<SoapHeader> GetHeaders(XmlNode node);
        /// <summary>
        /// Gets the SOAP body node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>SoapBody.</returns>
        SoapBody GetSoapBody(XmlNode node);
        /// <summary>
        /// Gets all operations from the raw SOAPUI prject file.
        /// </summary>
        /// <param name="Doc">The document.</param>
        /// <returns>XmlNodeList.</returns>
        XmlNodeList GetAllOperations(XmlDocument Doc);

    }
}
