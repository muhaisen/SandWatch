using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandWatch.Models
{
    class SoapUiUrl
    {
        public string Raw { get; set; }
        public string Protocol { get; set; }
        public List<string> Host { get; set; }
        public List<string> Path { get; set; }
        public List<string> Query { get; set; }

    }
}
