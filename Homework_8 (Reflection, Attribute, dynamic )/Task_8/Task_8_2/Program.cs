using System;
using System.Collections.Generic;

namespace Task_8_2
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var dict = new Dictionary<string, string>
                {
                    { "_name", "Dmitry" },
                    { "height", "1,83" }
                };

                var person = SimpleBinder.GetInstance().Bind<Person>(dict);
                Console.WriteLine(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}