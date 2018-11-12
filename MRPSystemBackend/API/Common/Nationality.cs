using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Common
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Adjective { get; set; }
        public string Person { get; set; }
    }
}
