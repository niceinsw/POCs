using System;

namespace MiscConsole.Enums
{
    public static class EnumUtil
    {
        public static T ParseEnum<T>(string value)
        {
            Type type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException($"{type} is not an enum.");

            if (!type.IsEnumDefined(value))
                throw new ArgumentException($"{value} is not a valid ordinal of type {type}.");

            //if (!Enum.IsDefined(typeof(T), value))
            //    throw new ArgumentException($"{value} is not a valid ordinal of type {type}.");

            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this string value)
        {
            Type type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException($"{type} is not an enum.");

            if (!type.IsEnumDefined(value))
                throw new ArgumentException($"{value} is not a valid ordinal of type {type}.");

            //if (!Enum.IsDefined(typeof(T), value))
            //    throw new ArgumentException($"{value} is not a valid ordinal of type {type}.");

            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this int value)
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException($"{type} is not an enum.");
            }

            if (!type.IsEnumDefined(value))
            {
                throw new ArgumentException($"{value} is not a valid ordinal of type {type}.");
            }

            return (T)Enum.ToObject(type, value);
        }
    }
}
