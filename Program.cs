using AmazedSaint.Elastic;
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
        static SoapReader _sr = new SoapReader();

        static void Main(string[] args)
        {
 
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
            //doc.Load(@"C:\AWS.xml");

           var Result =  _sr.GetInfo(doc);


            string xmlcontents = doc.InnerXml;

            var idk = doc.GetElementsByTagName("con:operation");
            string returnTxt =   PrintAll(idk);
            WriteItDown(returnTxt);
            //var tst =  doc.ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes[1];

        }
        static string PrintAll(XmlNodeList XmlList) {
            string AllText = "";
            foreach (XmlNode item in XmlList) {
                /////////////////
                var nodeName = _sr.GetOperatiomName(item);
                var a = _sr.GetURI(item);
                var ab = _sr.GetHeaders(item);
                var ac = _sr.GetSoapBody(item);
                ////////////////
                var call = item["con:call"];

               string Req = call["con:request"].InnerXml;
                string endpoint = call["con:endpoint"].InnerXml;

                int ends = Req.Length - 12;
                System.Diagnostics.Debug.WriteLine(endpoint);

                Req = Req.Substring(9, ends);
                Req = Req.Replace("\\r", "\\r\\n");


                AllText += endpoint + Environment.NewLine;
                AllText += Req + Environment.NewLine;

            }
            return AllText;
        }
        static void WriteItDown(string TheText) {
            string path = @"C:\Users\abmu\Desktop\lol.json";
            if (!File.Exists(path))
            { 
                File.WriteAllText(path, TheText);
            }
             File.AppendAllText(path, TheText);
        }
    }
}
