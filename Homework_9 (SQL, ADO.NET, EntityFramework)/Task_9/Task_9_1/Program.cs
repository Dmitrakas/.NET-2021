using System;

namespace Task_9_1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Read data from file");
            var reader = new FileReader("data.csv");
            var list = reader.Read();

            var repo = new Repository();
            Console.WriteLine("Delete info from DB");
            repo.DeleteEmployees();

            Console.WriteLine("Insert info in DB");
            repo.InsertEmployees(list);

            Console.WriteLine("Done");
        }
    }
}