using AmazedSaint.Elastic;
using Newtonsoft.Json.Linq;
using SandWatch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SandWatch
{
    class Program
    {
        // todo , change static to private.
        static SoapReader _sr = new SoapReader();
        static Constant _contstat;
        static void Main(string[] args)
        {
            _contstat = new Constant();
                          var cl = new WebClient();
            Console.WriteLine("Reading public time line");
            // To Read from URI      
                //  / //_//
               //  /_// \/         
             //var cl = new WebClient();
             //Console.WriteLine("Reading public time line");
             //using (var r = new StreamReader
             //    (cl.OpenRead(@"http://twitter.com/statuses/user_timeline/amazedsaint.xml")))
             //{
             //    var data = r.ReadToEnd();
             //    IterateTweets(data);
             //}
             XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\DiamondWebService.xml");

           var Result =  _sr.GetInfo(doc);


            string xmlcontents = doc.InnerXml;

            var idk = doc.GetElementsByTagName(_contstat.Operation);
            var returnTxt =   PrintAll(idk);
            ToJson(doc,returnTxt);
            //WriteItDown(returnTxt);
            //var tst =  doc.ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes[1];

        }
        static List<Item> PrintAll(XmlNodeList XmlList) {
            List<Item> Items = new List<Item>();
            foreach (XmlNode item in XmlList) {
                //////////////// Intitalize variables ////////
                Item VOitem = new Item();
                Request request = new Request();
                SoapBody Body = new SoapBody();
                List<SoapHeader> SoapHeaders = new List<SoapHeader>();
                ////////// Getting operation name ///////////
                VOitem.name = _sr.GetOperatiomName(item);
                ////////// Filling the request //////////////
                request.url = _sr.GetURI(item);
                request.method = _contstat.Post;
                request.description = "";
                ////// Filling the request body /////////////
                Body = _sr.GetSoapBody(item);
                ///// Filling the request  headers ////////
                SoapHeaders = _sr.GetHeaders(item);
                //////// Adding the header and body  the request
                request.header = SoapHeaders;
                request.body = Body;
                ///// Adding request to the item ///////////
                VOitem.request = request;
                VOitem.response = null;
                Items.Add(VOitem);
            }
            return Items;
        }
        static void WriteItDown(string TheText, string FileName) {
            string path = @_contstat.SavingPath + FileName + _contstat.Extention;
            if (!File.Exists(path))
            { 
                File.WriteAllText(path, TheText);
            }
            File.Delete(path);
            File.WriteAllText(path, TheText);
        }
        static void ToJson(XmlDocument Doc, List<Item> Operations)
        {
            SoapUiInfo info = _sr.GetInfo(Doc); 
            // Writing the Json Object
            JObject o = JObject.FromObject(new
            {
                variables = new List<String>(),
                info = new
                {
                    name = info.Name,
                    _postman_id = info.PostmanId,
                    description = info.Description,
                    schema = info.Schema,
                },
                // Looping over the items and add them in the list.
                    item =
             from p in Operations
             select new
             {
                 name = p.name,
                 request = new
                 {
                     url = p.request.url,
                     method = p.request.method,
                     ////// Headers
                     header = from h in p.request.header select new { key = h.key, value = h.value, description = String.Empty },
                     body = new { mode = p.request.body.mode, raw = p.request.body.Raw },
                     description = String.Empty,
                 },
                 response = new List<String>(),
             }                
            });
            // Write the json string to a file.
            WriteItDown(o.ToString(), info.Name);
        }
    }
}
