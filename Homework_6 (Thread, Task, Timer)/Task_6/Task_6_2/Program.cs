using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Task_6_2
{
    public class Program
    {
        public static void Main()
        {
            BigInteger a = 1234567890;
            BigInteger b = BigInteger.Parse("63018038201");

            FactorizationTest(a);
            FactorizationTest(b);

            FactorizationAsyncTest(a);
            FactorizationAsyncTest(b);

            GcdTest(a, 12345678);
            GcdTest(a, b);
        }

        private static void FactorizationTest(BigInteger number)
        {
            Console.WriteLine($"Factorization({number})");

            var result = BigInteger.One;
            foreach (var n in Mining.Factorization(number))
            {
                Console.WriteLine(n);
                result *= n;
            }

            Console.WriteLine($"Completed. {result == number}. {result}={number}");
            Console.WriteLine();
        }

        private static void FactorizationAsyncTest(BigInteger number)
        {
            Console.WriteLine($"FactorizationAsync({number})");

            var task = Mining.FactorizationAsync(number);
            Console.WriteLine("Get Task. Wait for Result");
            task.Wait();

            var result = BigInteger.One;
            foreach (var n in task.Result)
            {
                Console.WriteLine(n);
                result *= n;
            }

            Console.WriteLine($"Completed. {result == number}. {result}={number}");
            Console.WriteLine();
        }

        private static void GcdTest(BigInteger a, BigInteger b)
        {
            Console.WriteLine($"Gcd for {a} and {b}");
            Console.WriteLine($"Standard: {BigInteger.GreatestCommonDivisor(a, b)}");
            Task<BigInteger> task = Mining.GcdAsync(a, b);
            Console.WriteLine($"My code: {task.Result}");
            Console.WriteLine();
        }
    }
}