using DataReadingPerformace.Northwind.NorthwindDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataReadingPerformace.Northwind.Services
{
    public class OrdersService
    {
        public void LoadOrdersInLookup()
        {
            using (var db = new NorthwindModels())
            {
                LookupData.Orders = db.Orders.ToList();
                return;
            }
        }

        public MemoryCache LoadOrdersInCache()
        {
            var mem = new MemoryCache("NorthwindOrdersCache");

            using (var db = new NorthwindModels())
            {
                var orders = db.Orders.ToList();
                mem.Set("CacheOrders", orders, new CacheItemPolicy());
                return mem;
            }

            
        }

        public MemoryCache LoadOrdersInCache2()
        {
            var mem = new MemoryCache("NorthwindOrdersCache");
            var policy = new CacheItemPolicy();

            using (var db = new NorthwindModels())
            {
                foreach (var order in db.Orders)
                {
                    mem.Add(new CacheItem(order.OrderID.ToString(), order), policy);                    
                }                
                return mem;
            }

        }

        public MemoryCache LoadOrdersInCache3()
        {
            var mem = new MemoryCache("NorthwindOrdersCache");
            var policy = new CacheItemPolicy();
            int take = 3;


            using (var db = new NorthwindModels())
            {
                var orders = db.Orders.Take(3);
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
            var mem = new MemoryCache("NorthwindOrdersCache");
            var policy = new CacheItemPolicy();
            
            using (var db = new NorthwindModels())
            {                
                mem.Set(new CacheItem(order.OrderID.ToString(), order), policy);                
            }
        }
        public Order GetOrderFromDatbase(int orderId)
        {
            using (var db = new NorthwindModels())
            {
                return db.Orders.Find(orderId);
            }
        }

        public void Add3OrdersInLookup()
        {
            using (var db = new NorthwindModels())
            {
                LookupData.Orders = db.Orders.Take(3).ToList();
                return;
            }
        }

        //paged list models



    }
}
