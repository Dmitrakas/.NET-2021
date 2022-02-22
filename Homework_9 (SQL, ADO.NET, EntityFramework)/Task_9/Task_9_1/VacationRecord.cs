using System;
using System.Globalization;

namespace Task_9_1
{
    public class VacationRecord
    {
        private static readonly DateTime LowDate = new(2001, 1, 1);

        public string Person { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public VacationRecord(string person, DateTime start, DateTime end)
        {
            if (string.IsNullOrEmpty(person))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(person));
            }

            person = person.Trim();
            var names = person.Split(' ');
            if (names.Length != 2 || string.IsNullOrEmpty(names[0]) || string.IsNullOrEmpty(names[1]))
            {
                throw new ArgumentException("Incorrect format", nameof(person));
            }

            if (start < LowDate)
            {
                throw new ArgumentException("'start' date must be greater than 01/01/2001");
            }

            if (end < start)
            {
                throw new ArgumentException("'end' date must be greater or equals to 'start' date");
            }

            Person = person;
            Start = start.Date;
            End = end.Date;
        }

        public static VacationRecord Parse(string s)
        {
            var words = s.Split(',');
            var culture = new CultureInfo("en-US");
            var startDate = DateTime.Parse(words[1], culture);
            var endDate = DateTime.Parse(words[2], culture);
            return new VacationRecord(words[0], startDate, endDate);
        }

        public override string ToString() => $"{Person} {Start:d} - {End:d}";
    }
}