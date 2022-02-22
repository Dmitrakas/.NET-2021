using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_9_2.Entities
{
    public class Employee : Entity<Guid>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Vacation> Vacations { get; }
        public ICollection<Training> Trainings { get; }

        public string FullName => $"{FirstName} {LastName}";

        public bool IsVacationsOverlapped(DateTime low, DateTime high)
        {
            return Vacations.Any(x => x.StartDate <= high && low <= x.EndDate);
        }
    }
}