using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_7_1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Read data");
            var reader = new DataReader("data.csv");
            var list = reader.Read();

            Console.WriteLine("Get Average Vacation Length");
            Console.WriteLine(GetAverageVacationLength(list));

            Console.WriteLine("Get Person Average Vacation Length");
            var result = GetPersonAverageVacationLength(list).ToArray();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Write data");
            var writer = new DataWriter("persons.json");
            writer.Write(result);

            Console.WriteLine("Done");
        }

        private static double GetAverageVacationLength(List<Vacation> data)
        {
            return data.AsParallel().Average(x => x.Length);
        }

        private static IEnumerable<Person> GetPersonAverageVacationLength(List<Vacation> data)
        {
            return data.AsParallel().GroupBy(x => x.Person).Select(g => new Person(g.Key, g.Average(x => x.Length)));
        }
    }
}