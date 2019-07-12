using DataReadingPerformace.Northwind.NorthwindDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReadingPerformace.Northwind.Services
{
    public static class LookupData
    {
        public static List<Order> Orders { get; set; }

        public static List<TestOrder> TestOrders { get; set; }
    }
}
