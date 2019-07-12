using System;
using System.Collections.Generic;
using System.Linq;

namespace MiscConsole
{
    public static class CompareLists
    {
        public static void CompateTwoIntLists()
        {
            List<int> listA = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> listB = new List<int>() { 1, 2, 3, 5, 4 };

            //listA = listB;
            //var res = listA.Equals(listB);

            var res = listA.SequenceEqual(listB);

            Console.WriteLine(res);
        }

        public static void CompareIntList()
        {
            List<int> groupA = new List<int>() { 1, 7, 3, 6 };

            List<int> groupB = new List<int>() { 7, 6, 3, 1, 8 };

            var duplicates = groupA.Intersect(groupB).ToList();

            var distinctA = groupA.Except(groupB).ToList();

            var distinctB = groupB.Except(groupA).ToList();

            return;
        }

        public static void ListHasMatch()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 10 };

            List<int> list2 = new List<int> { 6, 7, 8, 9, 10 };

            var hasMatch = list1.Any(x => list2.Any(y => y == x));

            Console.WriteLine($"Has match: {hasMatch}");
        }
    }
}
