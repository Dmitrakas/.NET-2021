using System;
using System.Globalization;

namespace Task_7_1
{
    public class Vacation
    {
        public string Person { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public int Length => (End - Start).Days + 1;

        public Vacation(string person, DateTime start, DateTime end)
        {
            if (string.IsNullOrEmpty(person))
            {
                throw new ArgumentException("Cannot be null or empty.", nameof(person));
            }

            if (end < start)
            {
                throw new ArgumentException("The 'end' date must be greater than or equal to the 'start' date.");
            }

            Person = person;
            Start = start.Date;
            End = end.Date;
        }

        public static Vacation Parse(string s)
        {
            var words = s.Split(',');
            var culture = new CultureInfo("en-US");
            var startDate = DateTime.Parse(words[1], culture);
            var endDate = DateTime.Parse(words[2], culture);
            return new Vacation(words[0], startDate, endDate);
        }

        public override string ToString() => $"{Person} {Start:d} - {End:d}";
    }
}