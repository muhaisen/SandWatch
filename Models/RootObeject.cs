using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandWatch.Models
{
    public class RootObject
    {
        public List<object> variables { get; set; }
        public SoapUiInfo info { get; set; }
        public List<Item> item { get; set; }
    }
}
