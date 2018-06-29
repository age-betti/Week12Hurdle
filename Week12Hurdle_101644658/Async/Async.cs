using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    class Async
    {
        static void Main(string[] args)
        {
            Console.Write("Intensive processing coming up! Type some stuff: ");

            var task = FindPrimesAsync();

            var input = Console.ReadLine();

            Console.WriteLine("You typed: " + input);

        }

        public static async Task FindPrimesAsync()
        {
            var a = await FindPrimeNumberAsync(250000);
            var b = await FindPrimeNumberAsync(400000);

            Console.WriteLine(a);
            Console.WriteLine(b);

        }


        public static async Task<long> FindPrimeNumberAsync(int n)
        {
            return await Task.Run(() => FindPrimeNumber(n));
        }

        public static long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}
