using MiscConsole.Enums;
using System;
using static MiscConsole.Enums.EnumModels;

namespace MiscConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            //1
            //StringEqual.StringCompare();
            //new CreateJsonObject().CreateAndPrint();
            //new CacheDemo().PrintCache();

            //new JsonSerializeNamming().PrintJson();
            //new JsonPoc2().PrintJson();


            //2
            //string strNumber = "125";
            //int answer = 0;
            //int val = 20;
            //Console.WriteLine($"Before if block Answer: {answer}");

            //if (int.TryParse(strNumber, out answer))
            //{
            //    Console.WriteLine($"Inside Answer: {answer}");
            //}
            //Console.WriteLine($"After if block Answer: {answer}");

            //3: Json escape unescape
            //new JsonEscapeUnescape().Run();

            //DATE VALIDATION
            //var res = DateTimeDemos.ValidateDate(0004,2,29);


            //DateTimeDemos.TimeFunction();
            //DateTimeDemos.TimeZone();

            //DateTimeDemos.TimeDiffByZone();

            //var res = DateTimeDemos.StringtoDate("03/14/2019");
            //Console.WriteLine(res);

            //DemoEnums();


            //List comparison, compare list
            CompareLists.CompateTwoIntLists();
            CompareLists.CompareIntList();
            //CompareLists.ListHasMatch();

            Break();
        }

        public static void Break()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }



        public static void DemoEnums()
        {
            var service = new EnumService();
            //service.IntToEnum(2);
            //service.StringToEnum("Information");

            int a = 20;
            //var res = a.ToEnum<SeverityLevel>();

            var res1 = "Information".ToEnum<SeverityLevel>();
            //var res = "Tester".ToEnum<SeverityLevel>();
        }

    }
}
