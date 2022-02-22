using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_5_2
{
    class Book
    {
        private readonly string _name;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    throw new ArgumentException("Name can't be Null or Empty!");
                }

                return _name;
            }

        }
        public DateTime? Date { get; }
        public List<string> AuthorList { get; }

        public Book(string name, DateTime? dateTime, List<string> authorList)
        {
            _name = name;
            Date = dateTime;
            AuthorList = authorList.Distinct().ToList();
        }

        public override string ToString()
        {
            var authors = string.Empty;
            foreach (var item in AuthorList)
            {
                authors += $"{item} ";
            }

            return $"Name: {Name}\nDate: {Date}\nAuthors: {authors}\n";
        }
    }
}