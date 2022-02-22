using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Task_9_2
{
    public class Program
    {
        public static void Main()
        {
            VacationStatistics();
            TrainingAssignment();
        }

        private static void VacationStatistics()
        {
            Console.WriteLine("Employees with long vacation (more than 30 days):");

            using var context = CreateContextUsingConfig();
            foreach (var employee in context.Employees.Include(x => x.Vacations)
                .Where(x => x.Vacations.Any(v => EF.Functions.DateDiffDay(v.StartDate, v.EndDate) > 30)))
            {
                Console.WriteLine(employee.FullName);
            }

            Console.WriteLine("Done!");
        }

        private static void TrainingAssignment()
        {
            using var context = CreateContextUsingConfig();

            var list = context.Employees
                .Include(x => x.Trainings)
                .Include(x => x.Vacations)
                .ToList();

            AssignJavaScripTraining(new DateTime(2015, 09, 05), new DateTime(2015, 09, 29));
            AssignJavaScripTraining(new DateTime(2016, 04, 01), new DateTime(2016, 04, 25));

            context.SaveChanges();

            void AssignJavaScripTraining(DateTime start, DateTime end)
            {
                var training = context.Trainings
                    .SingleOrDefault(x => x.Name == "Modern JavaScript" &&
                                          x.StartDate == start &&
                                          x.EndDate == end);

                if (training == null)
                {
                    return;
                }

                var employees = list.Where(x => !x.IsVacationsOverlapped(start, end)).ToList();
                foreach (var employee in employees)
                {
                    employee.Trainings.Add(training);
                }

                Console.WriteLine($"Assigned to Training: {employees.Count}");
            }
        }

        private static AppContext CreateContextUsingConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connection = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder();
            var options = optionsBuilder.UseSqlServer(connection).Options;
            return new AppContext(options);
        }
    }
}