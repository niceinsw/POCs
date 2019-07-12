using DataReadingPerformace.Northwind.NorthwindDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataReadingPerformace.Northwind.Services
{
    public class TestOrdersService
    {
        private string CacheName { get; set; } = "NorthwindTestOrdersCache";
        public void LoadOrdersInLookup()
        {
            using (var db = new NorthwindModels())
            {
                LookupData.TestOrders = db.TestOrders.ToList();
                return;
            }
        }

        public MemoryCache LoadOrdersInCache()
        {
            var mem = new MemoryCache("NorthwindTestOrdersCache");

            using (var db = new NorthwindModels())
            {
                var orders = db.TestOrders.ToList();
                mem.Set("CacheTestOrders", orders, new CacheItemPolicy());
                return mem;
            }

            
        }

        public MemoryCache LoadOrdersInCache2()
        {
            var mem = new MemoryCache(CacheName);
            var policy = new CacheItemPolicy();

            using (var db = new NorthwindModels())
            {
                foreach (var order in db.TestOrders)
                {
                    mem.Add(new CacheItem(order.OrderID.ToString(), order), policy);                    
                }                
                return mem;
            }

        }

        public MemoryCache LoadOrdersInCache3()
        {
            var mem = new MemoryCache(CacheName);
            var policy = new CacheItemPolicy();
            int take = 3;


            using (var db = new NorthwindModels())
            {
                var orders = db.TestOrders.Take(3);
                foreach (var order in orders)
                {
                    mem.Add(new CacheItem(order.OrderID.ToString(), order), policy);
                }

                var newOrder = db.Orders.ToList().Skip(take).Take(1).FirstOrDefault();

                mem.Add(new CacheItem(newOrder.OrderID.ToString(), newOrder), policy);

                return mem;
            }

        }

        public void UpdateOrderInCache(Order order)
        {
            var mem = new MemoryCache(CacheName);
            var policy = new CacheItemPolicy();

            mem.Set(new CacheItem(order.OrderID.ToString(), order), policy);
        }
        public TestOrder GetOrderFromDatbase(int orderId)
        {
            using (var db = new NorthwindModels())
            {
                return db.TestOrders.Find(orderId);
            }
        }


        public void Add3OrdersInLookup()
        {
            using (var db = new NorthwindModels())
            {
                LookupData.TestOrders = db.TestOrders.Take(3).ToList();
                return;
            }
        }

    }
}
