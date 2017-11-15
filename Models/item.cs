using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandWatch.Models
{
    public class Item
    {
        public string name { get; set; }
        public Request request { get; set; }
        public List<object> response { get; set; }
    }
}
