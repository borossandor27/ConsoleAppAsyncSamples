using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAsyncLinking
{
    class Program
    {
        static void Main(string[] args)
        {
            callMethod();
            Console.WriteLine("program vége!");
            Console.ReadKey();
        }

        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task; //-- megvárja, amíg befejeződik a Method1()
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}
