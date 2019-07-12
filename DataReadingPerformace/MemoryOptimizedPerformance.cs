using DataReadingPerformace.Northwind.NorthwindDataModels;
using DataReadingPerformace.Northwind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReadingPerformace
{
    public class MemoryOptimizedPerformance
    {
        public int Counter { get; set; } = 10000;
        public int MinId { get; set; } = 10248;
        public int MaxId { get; set; } = 11077;
        public void Main()
        {
            PrintOrderFromDatabase();
            Break();

            PrintOrderFromDatabase();
            Break();

            PrintOrderFromDatabase();
            Break();
        }

        void Break()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        void PrintOrderFromDatabase()
        {
            Random random = new Random();

            var startTime = DateTime.Now;

            var service = new TestOrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);                
                var order = service.GetOrderFromDatbase(orderID);
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            //Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            //Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);

        }

        void PrintOrderFromStaticData()
        {
            new TestOrdersService().LoadOrdersInLookup();
            Random random = new Random();

            var startTime = DateTime.Now;

            var service = new TestOrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);                
                var order = LookupData.TestOrders.Where(o => o.OrderID == orderID).FirstOrDefault();
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            //Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            //Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);

        }

        void Print3OrderAndUpdateOneFromStaticData()
        {
            new TestOrdersService().Add3OrdersInLookup();

            var startTime = DateTime.Now;

            var service = new TestOrdersService();

            foreach (var order in LookupData.TestOrders)
            {
                if (order.OrderID == 10249)
                {
                    order.ShipName = order.ShipName + " Updated";
                }
                Console.WriteLine($"OrderId: {order.OrderID}. Ship Name: {order.ShipName}");
            }

            foreach (var order in LookupData.TestOrders)
            {
                Console.WriteLine($"OrderId: {order.OrderID}. Ship Name: {order.ShipName}");
            }

            Break();

        }

        public void PrintOrderUsingMemoryCache()
        {
            var res = new TestOrdersService().LoadOrdersInCache();

            Random random = new Random();
            var startTime = DateTime.Now;
            var service = new TestOrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                var order = ((List<TestOrder>)res.Get("CacheTestOrders")).Where(o => o.OrderID == orderID).FirstOrDefault();
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);
        }

        void PrintOrderUsingMemoryCache2()
        {
            var res = new TestOrdersService().LoadOrdersInCache2();

            Random random = new Random();
            var startTime = DateTime.Now;
            var service = new TestOrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                var order = (TestOrder)res.Get(orderID.ToString());
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);
        }

        void PrintOrderUsingMemoryCache3()
        {
            var res2 = new TestOrdersService().LoadOrdersInCache3();

            var count = res2.Count();

            Console.WriteLine("Count: " + count);

            Break();

            var res = new TestOrdersService().LoadOrdersInCache3();

            Random random = new Random();
            var startTime = DateTime.Now;
            var service = new TestOrdersService();
            for (int i = 0; i < Counter; i++)
            {
                var orderID = random.Next(MinId, MaxId);
                var order = (TestOrder)res.Get(orderID.ToString());
                Console.WriteLine($"Ship Name: {order.ShipName}");
            }

            Console.WriteLine("Start Time: " + startTime.ToString("HH:mm:ss"));

            var endTime = DateTime.Now;
            Console.WriteLine("EndTime Time: " + endTime.ToString("HH:mm:ss"));
            Console.WriteLine("Time Taken (seconds): " + (endTime - startTime).TotalSeconds);
        }

        void PrintAndUpdateOrderUsingMemoryCache3()
        {
            //var res2 = new TestOrdersService().LoadOrdersInCache3();

            //var count = res2.Count();

            //Console.WriteLine("Count: " + count);

            var service = new TestOrdersService();
            var res = service.LoadOrdersInCache3();


            for (int i = 10248; i < 10252; i++)
            {
                var order = (TestOrder)res.Get(i.ToString());

                Console.WriteLine($"Ship Name: {order.ShipName}");

                order.ShipName = order.ShipName + " UPDATED";
            }

            Console.WriteLine("----------------------------------------------");

            for (int i = 10248; i < 10252; i++)
            {
                var order = (TestOrder)res.Get(i.ToString());

                Console.WriteLine($"Ship Name: {order.ShipName}");

                //order.ShipName = order.ShipName + " UPDATED";
            }

            Break();

        }

    }
}
