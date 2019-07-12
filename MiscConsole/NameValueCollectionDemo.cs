using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace MiscConsole
{
    public static class NameValueCollectionDemo
    {
        public static void Demo()
        {
            var collection = GetCollection();

            foreach (var key in collection.AllKeys)
            {
                Console.WriteLine($"Key: {key} and Value: {collection[key]}");
            }

        }

        private static NameValueCollection GetCollection()
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("Id", "700");
            collection.Add("FirstName", "Muhammad");
            collection.Add("LastName", "Ramzan");
            collection.Add("Company", "smoothwall");

            return collection;
        }
    }
}
