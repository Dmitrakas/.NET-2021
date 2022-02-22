using System;
using Task_8_1_Library;

namespace Task_8_1
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var person = new Person("Dmitry", "Zhorovin", 22);       
                var logger = new Logger("Logger.log");

                logger.Track(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}