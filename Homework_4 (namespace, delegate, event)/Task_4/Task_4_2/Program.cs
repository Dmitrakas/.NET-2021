using System;

namespace Task_4_2
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var r0 = new RationalNumber();
                var r1 = new RationalNumber(71, 32);
                var r2 = new RationalNumber(178, 46);
                var r3 = r1 + r2;
                var r4 = r1 - r2;
                var r5 = r1 * r2;
                var r6 = r1 / r2;

                const int number = 17;
                RationalNumber r7 = number;
                var d = (double)r1;

                Console.WriteLine(r0);
                Console.WriteLine(r1);
                Console.WriteLine(r2);
                Console.WriteLine(r3);
                Console.WriteLine(r4);
                Console.WriteLine(r5);
                Console.WriteLine(r6);

                Console.WriteLine(r7);
                Console.WriteLine($"Double value: {d}");

                Console.WriteLine(r1.CompareTo(r2));
                Console.WriteLine(r1.Equals(r2));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.Read();
        }
    }
}