using System;
using System.Collections.Generic;

namespace Task_5_2
{
    class Program
    {
        static void Main()
        {
            var book1 = new Book("A Book", new DateTime(2021, 11, 22), new List<string>() { "Author1", "Author2", "Author2", "Author2" });
            var book2 = new Book("B Book", DateTime.Today, new List<string>() { "Author1", "Author3" });
            var book3 = new Book("C Book", null, new List<string>());
            var book4 = new Book("D Book", null, new List<string>());
            var catalog1 = new Catalog { { "123-4-56-789012-3", book1 }, { "1234567890124", book2 }, { "123-4-56-789012-5", book3 } };

            Console.WriteLine(catalog1);
            Console.WriteLine(catalog1["1234567890123"]);
            Console.WriteLine(catalog1["123-4-56-789012-3"]);

            foreach (var item in catalog1.GetBookNamesOrderedByAlphabet())
            {
                Console.WriteLine(item);
            }

            foreach (var item in catalog1.GetBooksByAuthorNameOrderedByDate("Author1"))
            {
                Console.WriteLine(item);
            }

            foreach (var item in catalog1.GetTuplesAuthorNameAuthorBooksCount())
            {
                Console.WriteLine(item);
            }
        }
    }
}