using System;
using System.Threading.Tasks;

namespace MiscConsole
{
    public class FireAndForget
    {
        public void CallFAF()
        {
            //Fire and Forget
            //Task.Run(async () => await FireAwayAsync());
            //Task.Run(() => FireAway());
        }

        static async Task FireAwayAsync()
        {
            await Task.Delay(5000);
            //System.Threading.Thread.Sleep(5000);
            Console.WriteLine("5 seconds later");
        }

        static void FireAway()
        {
            Task.Run(async () => await Task.Delay(5000));
            //System.Threading.Thread.Sleep(5000);
            Console.WriteLine("5 seconds later");
        }
    }
}
