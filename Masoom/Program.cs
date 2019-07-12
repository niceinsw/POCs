using System;
using System.Text;

namespace Masoom
{
    public class Program
    {
        static void Main(string[] args)
        {
            string value = "proto tcp";// "c6d8d2cadce814c8ca";

            Encoding encoding = Encoding.Default;
            var bytes = encoding.GetBytes(value);

            var res = Decrypt(bytes);

            string converted = new string(res);

            Console.WriteLine(converted);

            Break();
        }

        static void Break()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static char[] Decrypt(byte[] bytes)
        {
            char[] hexArray = "0123456789ABCDEF".ToCharArray();

            char[] hexChars = new char[(bytes.Length * 2)];

            for (int j = 0; j < bytes.Length; j++)
            {
                int v = bytes[j] & 255;

                hexChars[j * 2] = hexArray[ShiftInArray(v)];
                hexChars[(j * 2) + 1] = hexArray[v & 15];
            }

            //return new String(hexChars);
            return hexChars;
        }

        static int ShiftInArray(int x)
        {
            int y = (int)((uint)x >> 4);
            return y;
        }


        static void POCs()
        {
            var bytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            int v = (bytes[3] & 255);


            int x = 16;
            int y = (int)((uint)x >> 1);
            Console.WriteLine(Convert.ToString(y, 2));

            Console.WriteLine(v);
        }


    }
}
