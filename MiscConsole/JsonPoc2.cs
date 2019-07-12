using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole
{
    public class JsonPoc2
    {
        public void PrintJson()
        {
            var tenant = new TenantPoc()
            {
                Id = 1,
                Name = "Tenant",
                Users = new List<TenantUserPoc>()
                {
                    new TenantUserPoc(){Id =1,Name ="User 1", TenantId = 1 },
                    new TenantUserPoc(){Id =2,Name ="User 2", TenantId = 1 }
                }
            };


            var strTenant = JsonConvert.SerializeObject(tenant);

            Console.WriteLine(strTenant);
        }
    }

    public class TenantPoc
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("MyUsers")]
        public List<TenantUserPoc> Users { get; set; }        
    }


    public class TenantUserPoc
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
    }
}
