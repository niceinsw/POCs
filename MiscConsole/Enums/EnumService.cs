using System;
using static MiscConsole.Enums.EnumModels;

namespace MiscConsole.Enums
{
    public class EnumService
    {
        public void IntToEnum(int value)
        {
            var isDefined = Enum.IsDefined(typeof(SeverityLevel), value);

            if (isDefined)
            {
                Console.WriteLine($"Enum is defined for value: {value}");
                var severityLevel = (SeverityLevel)value;
                Console.WriteLine($"Int to Enum, SeverityLevel for {value} : {severityLevel}");
            }
            else
            {
                Console.WriteLine($"No enum defined for value: {value}");
            }
        }

        public void StringToEnum(string value)
        {
            var isDefined = Enum.IsDefined(typeof(SeverityLevel), value);

            if (isDefined)
            {
                Console.WriteLine($"Enum is defined for value: {value}");
                Enum.TryParse(value, out SeverityLevel severityLevel);
                Console.WriteLine($"Int to Enum, SeverityLevel for {value} : {severityLevel}");
            }
            else
            {
                Console.WriteLine($"No enum defined for value: {value}");
            }
        }

    }
}
