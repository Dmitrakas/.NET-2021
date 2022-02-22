using System;

namespace Task_9_2.Entities
{
    public class Vacation : Entity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeId { get; set; }

        public override string ToString() => $"From {StartDate:d} to {EndDate:d}";
    }
}