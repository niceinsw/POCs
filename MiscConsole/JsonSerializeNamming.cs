using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiscConsole
{
    public class JsonSerializeNamming
    {

        public void PrintJson()
        {
            var tenants = GetData();

            var response = new Response();
            response.customers = new List<ResponseCustomer>();


            var resTenants = new List<ResponseTenant>();

            foreach (var item in tenants)
            {
                var catList = item.Categories.Select(c => c.Name).ToList();
                var devList = item.Users.Select(c => c.Name).ToList();
                var userList = item.Devices.Select(c => c.Name).ToList();

                var resTenant = new ResponseTenant()
                {
                    categories = catList,
                    devices = devList,
                    users = userList
                };

                resTenants.Add(resTenant);
            }



            response.customers.Add(new ResponseCustomer()
            {
                customerId = "12",
                tenants = resTenants
            });


            var strResponse = JsonConvert.SerializeObject(response);

            Console.WriteLine(strResponse);

            ConvertToCS(strResponse);
        }

        private List<Tenant> GetData()
        {
            var tenant1 = new Tenant()
            {
                Id = 1,
                Name = "T1",
                Users = new List<TenantUser>()
                {
                    new TenantUser(){Id = 1, Name = "T1 U1", TenantId = 1},
                    new TenantUser(){Id = 2, Name = "T1 U2", TenantId = 1},
                    new TenantUser(){Id = 2, Name = "T1 U3", TenantId = 1},
                },
                Devices = new List<TenantDevice>()
                {
                    new TenantDevice(){Id = 1, Name = "T1 Device1", TenantId = 1},
                    new TenantDevice(){Id = 2, Name = "T1 Device2", TenantId = 1},
                    new TenantDevice(){Id = 2, Name = "T1 Device3", TenantId = 1},
                },
                Categories = new List<TenantCategory>()
                {
                    new TenantCategory(){Id = 1, Name = "T1 Cat1", TenantId = 1},
                    new TenantCategory(){Id = 2, Name = "T1 Cat2", TenantId = 1},
                    new TenantCategory(){Id = 2, Name = "T1 Cat3", TenantId = 1},
                }
            };

            var tenant2 = new Tenant()
            {
                Id = 2,
                Name = "T1",
                Users = new List<TenantUser>()
                {
                    new TenantUser(){Id = 1, Name = "T2 U1", TenantId = 2},
                    new TenantUser(){Id = 2, Name = "T2 U2", TenantId = 2},
                    new TenantUser(){Id = 2, Name = "T2 U3", TenantId = 2},
                },
                Devices = new List<TenantDevice>()
                {
                    new TenantDevice(){Id = 1, Name = "T2 Device1", TenantId = 2},
                    new TenantDevice(){Id = 2, Name = "T2 Device2", TenantId = 2},
                    new TenantDevice(){Id = 2, Name = "T2 Device3", TenantId = 2},
                },
                Categories = new List<TenantCategory>()
                {
                    new TenantCategory(){Id = 1, Name = "T2 Cat1", TenantId = 2},
                    new TenantCategory(){Id = 2, Name = "T2 Cat2", TenantId = 2},
                    new TenantCategory(){Id = 2, Name = "T2 Cat3", TenantId = 2},
                }
            };


            var tenantList = new List<Tenant>();
            tenantList.Add(tenant1);
            tenantList.Add(tenant2);

            return tenantList;
        }

        private void ConvertToCS(string strJson)
        {
            var obj = JsonConvert.DeserializeObject<Response>(strJson);

            return;
        }

    }





    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TenantUser> Users { get; set; }
        public List<TenantDevice> Devices { get; set; }
        public List<TenantCategory> Categories { get; set; }
    }

    public class TenantUser
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
    }

    public class TenantDevice
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
    }

    public class TenantCategory
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
    }


    /////
    ///
    public class ResponseTenant
    {
        public string tenantname { get; set; }
        public List<string> users { get; set; }
        public List<string> devices { get; set; }
        public List<string> categories { get; set; }
    }

    public class ResponseCustomer
    {
        public string customerId { get; set; }
        public List<ResponseTenant> tenants { get; set; }
    }

    public class Response
    {
        public List<ResponseCustomer> customers { get; set; }
    }
}
