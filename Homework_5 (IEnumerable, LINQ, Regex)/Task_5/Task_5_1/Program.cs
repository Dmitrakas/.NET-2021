using System;

namespace Task_5_1
{
    internal class Program
    {
        private static void Main()
        {
            var matrix = new SparseMatrix(10, 10)
            {
                [0, 0] = 10,
                [0, 9] = 20,
                [9, 0] = 30,
                [9, 9] = 40
            };

            Console.WriteLine(matrix);

            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }

            foreach (var item in matrix.GetNonzeroElements())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Count: {matrix.GetCount(0)}"); 

            Console.ReadLine();
        }
    }
}