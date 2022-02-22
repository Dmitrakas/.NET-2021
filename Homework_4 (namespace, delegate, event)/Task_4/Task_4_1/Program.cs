using System;

namespace Task_4_1
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var a = new DiagonalMatrix<int>(3)
                {
                    [0, 0] = 5,
                    [1, 1] = 1,
                    [2, 2] = 3
                };
                Console.WriteLine(a);
                var b = new MatrixTracker<int>(a);
                a[0, 0] = 7;
                Console.WriteLine(a);
                b.Undo();
                Console.WriteLine(a);

                var c = new DiagonalMatrix<int>(5)
                {
                    [0, 0] = 4,
                    [1, 1] = 3,
                    [2, 2] = 2,
                    [3, 3] = 1,
                    [4, 4] = 7
                };
                Console.WriteLine(c);
                Console.WriteLine(a.Add(c, (arg1, arg2) => arg1 + arg2));

                var str = new DiagonalMatrix<string>(3);
                Console.WriteLine(str);
                str[0, 0] = "first";
                str[1, 1] = "second";
                str[2, 2] = "third";
                Console.WriteLine(str);
                var str2 = new MatrixTracker<string>(str);
                str[0, 0] = "zero1";
                str[1, 1] = "zero2";
                str[2, 2] = "zero3";
                Console.WriteLine(str);
                str2.Undo();
                Console.WriteLine(str);
                str2.Undo();
                Console.WriteLine(str);
                str2.Undo();
                Console.WriteLine(str);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.Read();
        }
    }
}