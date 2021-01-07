using MiscConsole.Enums;
using System;
using System.Collections.Generic;
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
            //CompareLists.CompateTwoIntLists();
            //CompareLists.CompareIntList();
            //CompareLists.ListHasMatch();


            DemoSociableTime();
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


        public static void DemoSociableTime()
        {
            var timeList = new List<SocialTime>
            {
                new SocialTime {startHour = 20, endHour = 08},
                new SocialTime {startHour = 21, endHour = 07},
                new SocialTime {startHour = 22, endHour = 06},
                new SocialTime {startHour = 23, endHour = 05},
                new SocialTime {startHour = 00, endHour = 04},
                new SocialTime {startHour = 1, endHour = 03},
                new SocialTime {startHour = 2, endHour = 02},
                new SocialTime {startHour = 19, endHour = 01},
                new SocialTime {startHour = 18, endHour = 00},
                new SocialTime {startHour = 17, endHour = 23},
                new SocialTime {startHour = 16, endHour = 22},
                new SocialTime {startHour = 15, endHour = 21},
                new SocialTime {startHour = 14, endHour = 20},
                new SocialTime {startHour = 13, endHour = 19},
                new SocialTime {startHour = 12, endHour = 18},
                new SocialTime {startHour = 11, endHour = 17},
                new SocialTime {startHour = 10, endHour = 16},
                new SocialTime {startHour = 09, endHour = 15},
                new SocialTime {startHour = 8, endHour = 14},
                new SocialTime {startHour = 7, endHour = 13},
                new SocialTime {startHour = 6, endHour = 12},
                new SocialTime {startHour = 5, endHour = 11},
                new SocialTime {startHour = 4, endHour = 10},
                new SocialTime {startHour = 3, endHour = 9},
                new SocialTime {startHour = 2, endHour = 8},
                new SocialTime {startHour = 1, endHour = 16}
            };

            foreach (var time in timeList)
            {
                Console.WriteLine($"StartHour: {time.startHour}, EndHour: {time.endHour} ----- Next time: {GetSendTime(time.startHour, time.endHour)}");
            }

        }

        public static DateTime GetSendTime(int startHour, int endHour)
        {
            DateTime startTime = new DateTime(2020, 10, 15, startHour, 00, 00);
            DateTime endTime = new DateTime(2020, 10, 15, endHour, 00, 00);

            //var givenTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, hours, minutes, 00);
            //var givenHour = givenTime.Hour;

            if (startTime.Hour >= 12 && endTime.Hour < 12)
            {
                endTime = endTime.AddDays(1);
            }

            return endTime.AddMinutes(1);
        }
    }

    public class SocialTime
    {
        public int startHour { get; set; }
        public int endHour { get; set; }
    }
}
