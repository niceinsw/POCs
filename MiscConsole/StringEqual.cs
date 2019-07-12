using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole
{
    public static class StringEqual
    {
        public static void StringCompare()
        {
            var strList = new List<string>() { "one", "two", "three", "pending" };


            var strList2 = new List<string>() { "one1", "two1", "three1", "Pending", "THREE" };


            var status = "Pending";

            var test = strList.Where(s => strList2.Contains(s, StringComparer.OrdinalIgnoreCase)).ToList();


            var contains = strList.Contains(status);

            var contain2 = strList.Where(s => s.Equals(status, StringComparison.InvariantCultureIgnoreCase)).Count() > 0;

            var contain3 = strList.Any(s => s.Equals(status));

            var res = status.IsEqual("hello");
        }

        public static bool IsEqual(this string str, string value)
        {
            return str.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
