using System;
using System.Threading.Tasks;

namespace Task_7_2
{
    public class Program
    {
        public static async Task Main()
        {
            var dataReader = new DataReader("data.txt");
            var data = dataReader.Read();
            data.ForEach(Console.WriteLine);

            await foreach (var point in Point.Produce(10))
            {
                var result = KnnClassifier.Classify(data, point);
                Console.WriteLine(result);
            }
        }
    }
}