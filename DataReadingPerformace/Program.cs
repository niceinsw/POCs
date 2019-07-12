using DataReadingPerformace.Northwind.NorthwindDataModels;
using DataReadingPerformace.Northwind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataReadingPerformace
{
    public static class Program
    {        
        public static int Counter { get; set; } = 100000;
        public static int MinId { get; set; } = 10248;
        public static int MaxId { get; set; } = 11077;
        static void Main(string[] args)
        {

            //var res = new OrderPagedService().GetOrdersFromDatbase();
            new MemoryOptimizedPerformance().PrintOrderUsingMemoryCache();
            Break();

            //PrintOrderFromDapper();
            //Break();

            //PrintOrderFromDapper();
            //Break();

            //PrintOrderFromDapper();
            //Break();                        
        }

        static void Break()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void PrintOrderFromDatabase()
        {
            Random random = new Random();

            var startTime = DateTime.Now;

            var service = new OrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                //var order = new OrdersService().GetOrderFromDatbase(orderID);
                var order = service.GetOrderFromDatbase(orderID);
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            //Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            //Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);
                        
        }

        static void PrintOrderFromDapper()
        {
            Random random = new Random();

            var startTime = DateTime.Now;

            var service = new DapperOrderService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                //var order = new OrdersService().GetOrderFromDatbase(orderID);
                var order = service.GetOrder(orderID);
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            //Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            //Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);

        }

        static void PrintOrderFromStaticData()
        {
            new OrdersService().LoadOrdersInLookup();
            Random random = new Random();

            var startTime = DateTime.Now;

            var service = new OrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                //var order = new OrdersService().GetOrderFromDatbase(orderID);
                var order = LookupData.Orders.Where(o=>o.OrderID==orderID).FirstOrDefault();
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            var endTime = DateTime.Now;
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);

        }

        static void Print3OrderAndUpdateOneFromStaticData()
        {
            new OrdersService().Add3OrdersInLookup();         

            var startTime = DateTime.Now;

            var service = new OrdersService();

            foreach (var order in LookupData.Orders)
            {
                if (order.OrderID == 10249)
                {
                    order.ShipName = order.ShipName + " Updated";
                }
                Console.WriteLine($"OrderId: {order.OrderID}. Ship Name: {order.ShipName}");
            }

            foreach (var order in LookupData.Orders)
            {                
                Console.WriteLine($"OrderId: {order.OrderID}. Ship Name: {order.ShipName}");
            }

            Break();           

        }

        static void PrintOrderUsingMemoryCache()
        {
            var res = new OrdersService().LoadOrdersInCache();

            Random random = new Random();
            var startTime = DateTime.Now;
            var service = new OrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);                
                var order = ((List<Order>)res.Get("CacheOrders")).Where(o => o.OrderID == orderID).FirstOrDefault();
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);
        }

        static void PrintOrderUsingMemoryCache2()
        {
            var res = new OrdersService().LoadOrdersInCache2();

            Random random = new Random();
            var startTime = DateTime.Now;
            var service = new OrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                var order = (Order)res.Get(orderID.ToString());
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);
        }

        static void PrintOrderUsingMemoryCache3()
        {
            var res2 = new OrdersService().LoadOrdersInCache3();

            var count = res2.Count();

            Console.WriteLine("Count: " + count);

            Break();

            var res = new OrdersService().LoadOrdersInCache3();

            Random random = new Random();
            var startTime = DateTime.Now;
            var service = new OrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                var order = (Order)res.Get(orderID.ToString());
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);
        }

        static void PrintAndUpdateOrderUsingMemoryCache3()
        {
            //var res2 = new OrdersService().LoadOrdersInCache3();

            //var count = res2.Count();

            //Console.WriteLine("Count: " + count);
                        
            var service = new OrdersService();
            var res = service.LoadOrdersInCache3();

            
            for (int i = 10248; i < 10252; i++)
            {                
                var order = (Order)res.Get(i.ToString());

                Console.WriteLine($"Ship Name: {order.ShipName}");

                order.ShipName = order.ShipName + " UPDATED";
            }

            Console.WriteLine("----------------------------------------------");

            for (int i = 10248; i < 10252; i++)
            {
                var order = (Order)res.Get(i.ToString());

                Console.WriteLine($"Ship Name: {order.ShipName}");

                //order.ShipName = order.ShipName + " UPDATED";
            }

            Break();

        }
    }
}
