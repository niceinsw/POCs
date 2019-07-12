using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole.CacheManager
{
    public class Tenant
    {
        public string name { get; set; }
        public List<string> users { get; set; }
        public List<string> devices { get; set; }
        public List<string> categories { get; set; }
    }

    public class CacheModel
    {
        public List<Tenant> Tenants { get; set; }
    }
}
