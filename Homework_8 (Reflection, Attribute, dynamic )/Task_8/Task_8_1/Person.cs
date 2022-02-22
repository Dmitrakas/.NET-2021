using System;
using Task_8_1_Library;

namespace Task_8_1
{
    [TrackingEntity]
    public class Person
    {
        [TrackingProperty("married")]
        private bool _married = false;
        [TrackingProperty]
        public string FirstName { get; }
        [TrackingProperty]
        public string SecondName { get; }
        [TrackingProperty]
        public int Age { get; }

        public Person(string firstname, string secondname, int age)
        {
            FirstName = firstname ?? throw new ArgumentNullException(nameof(firstname));
            SecondName = secondname ?? throw new ArgumentNullException(nameof(secondname));

            if (age < 0)
            {
                throw new ArgumentException("Age must be more than 0!");
            }

            Age = age;
        }
    }
}