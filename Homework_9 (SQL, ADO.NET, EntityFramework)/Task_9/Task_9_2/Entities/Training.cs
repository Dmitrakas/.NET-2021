using System;
using System.Collections.Generic;

namespace Task_9_2.Entities
{
    public class Training : Entity<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; }
    }
}