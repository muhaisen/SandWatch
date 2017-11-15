
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandWatch.Models
{
    public class Request
    {
        public string url { get; set; }
        public string method { get; set; }
        public List<SoapHeader> header { get; set; }
        public SoapBody body { get; set; }
        public string description { get; set; }
    }
}
