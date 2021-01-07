using System;
using System.Collections.Generic;

namespace MiscConsole.CacheManager
{
    public class CacheDemo
    {
        public void PrintCache()
        {
            //var tenantList = new List<Tenant>()
            //    {
            //        new Tenant()
            //        {
            //            name = "Tenant 1",
            //            users = new List<string>(){ "T1 user one", "T1 user two" },
            //            categories = new List<string>(){ "T1 cat one", "T1 cate two" },
            //            devices = new List<string>(){ "T1 device one", "T1 device two" }
            //        },
            //        new Tenant()
            //        {
            //            name = "Tenant 2",
            //            users = new List<string>(){ "T2 user one", "T2 user two" },
            //            categories = new List<string>(){ "T2 cat one", "T2 cate two" },
            //            devices = new List<string>(){ "T2 device one", "T2 device two" }
            //        }
            //    };

            var cache = new CacheModel()
            {
                Tenants = new List<Tenant>()
                {
                    new Tenant()
                    {
                        name = "Tenant 1",
                        users = new List<string>(){ "T1 user one", "T1 user two" },
                        categories = new List<string>(){ "T1 cat one", "T1 cate two" },
                        devices = new List<string>(){ "T1 device one", "T1 device two" }
                    },
                    new Tenant()
                    {
                        name = "Tenant 2",
                        users = new List<string>(){ "T2 user one", "T2 user two" },
                        categories = new List<string>(){ "T2 cat one", "T2 cate two" },
                        devices = new List<string>(){ "T2 device one", "T2 device two" }
                    }
                }

            };

            var strCache = ""; //JsonConvert.SerializeObject(cache);

            Console.WriteLine(strCache);
            Console.WriteLine("=======================================================");

            var tenantList = new List<Tenant>()
                {
                    new Tenant()
                    {
                        name = "Tenant 1",
                        users = new List<string>(){ "T1 user one", "T1 user two" },
                        categories = new List<string>(){ "T1 cat one", "T1 cate two" },
                        devices = new List<string>(){ "T1 device one", "T1 device two" }
                    },
                    new Tenant()
                    {
                        name = "Tenant 2",
                        users = new List<string>(){ "T2 user one", "T2 user two" },
                        categories = new List<string>(){ "T2 cat one", "T2 cate two" },
                        devices = new List<string>(){ "T2 device one", "T2 device two" }
                    }
                };

            var strTenants = ""; // JsonConvert.SerializeObject(tenantList);
            //Console.WriteLine(strTenants);
        }
    }
}
