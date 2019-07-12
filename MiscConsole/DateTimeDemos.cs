using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole
{
    public static class DateTimeDemos
    {

        public static DateTime StringtoDate(string strDate)
        {
            DateTime res = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return res;
        }
        public static bool ValidateDate(int year, int month, int day)
        {
            try
            {
                DateTime dt = new DateTime(year, month, day);
                return true;
            }
            catch {
                return false;
            }            
        }

        public static void TimeFunction()
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 1, 0);

            int mul = -1;
            double difference = 11;
            double addHours = difference * mul;

            var res = dateTime.AddHours(addHours);

            Console.WriteLine($"UK Time: {dateTime}\nDifference: {difference}\nRes: {res}");

        }

        public static void TimeZone()
        {               
            ReadOnlyCollection<TimeZoneInfo> tz;
            tz = TimeZoneInfo.GetSystemTimeZones();

            foreach (var zone in tz)
            {
                Console.WriteLine($"Id: {zone.Id} ---- Display Name: {zone.DisplayName} ---- Diff minutes: {zone.BaseUtcOffset.TotalMinutes}");
            }

            string tzId = "Pakistan Standard Time";
            var res = tz.Where(t => t.Id == tzId).FirstOrDefault();
        }

        public static void TimeDiffByZone(string zoneId = "Pakistan Standard Time")
        {
            zoneId = "UTC";
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 1, 0);
            var utcDateTime = dateTime.ToUniversalTime();
                        
            var tz = TimeZoneInfo.GetSystemTimeZones();

            foreach (var item in tz)
            {
                Console.WriteLine($"{item.DisplayName}");
            }


            var zone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);

            var mul = -1;
            var zoneDiff = zone.BaseUtcOffset.TotalMinutes;
            var diffMinutes = zoneDiff * mul;

            var res = utcDateTime.AddMinutes(diffMinutes);

            Console.WriteLine($"Res: {res}");
        }
    }
}
