using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SandWatch.Models
{
    interface ISoapReader
    {
        SoapUiInfo GetInfo(XmlDocument doc);
        string GetOperatiomName(XmlNode node);
        string GetURI(XmlNode node);
        List<SoapHeader> GetHeaders(XmlNode node);
        List<string> GetHost(XmlDocument doc);
        List<string> GetPath(XmlDocument doc);
        List<string> GetQuery(XmlDocument doc);
        SoapBody GetSoapBody(XmlNode node);
    }
}
