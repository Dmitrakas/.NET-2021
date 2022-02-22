namespace Task_8_2
{
    public class Person
    {
        private string _name;
        public double Height { get; set; }

        public Person()
        {
        }

        public override string ToString()
        {
            return $"{_name} : {Height}m";
        }
    }
}