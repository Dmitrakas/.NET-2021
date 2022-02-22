using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_5_2
{
    class Catalog : Dictionary<string, Book>
    {
        private readonly Regex _isbnFormatDash = new("[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}");
        private readonly Regex _isbnFormatNoDash = new("[0-9]{13}");

        public new void Add(string isbn, Book item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));
            if (IsValidFormat(isbn))
            {
                isbn = isbn.Replace("-", "");
                base.Add(isbn, item);
            }
            else
            {
                throw new FormatException();
            }
        }

        public new void Remove(string isbn)
        {
            if (IsValidFormat(isbn))
            {
                isbn = isbn.Replace("-", "");
                base.Remove(isbn);
            }
            else
            {
                throw new FormatException();
            }
        }
        public new Book this[string isbn]
        {
            get
            {
                isbn = isbn.Replace("-", "");
                return base[isbn];
            }

        }
        public override string ToString()
        {
            var res = string.Empty;
            foreach (var item in this)
            {
                res += $"{item.Value}\n";
            }

            return res;
        }
        public List<string> GetBookNamesOrderedByAlphabet()
        {
            return this.Select(element => element.Value.Name).OrderBy(name => name).ToList();
        }

        public List<Book> GetBooksByAuthorNameOrderedByDate(string author)
        {
            return this.Select(element => element.Value).Where(book => book.AuthorList.Contains(author))
                .OrderBy(book => book.Date).ToList();
        }

        public List<(string, int)> GetTuplesAuthorNameAuthorBooksCount()
        {
            var authorList = this.SelectMany(element => element.Value.AuthorList).Distinct().ToList();
            var result = authorList.Select(item => (item, this.Select(element =>
                element.Value).Count(book => book.AuthorList.Contains(item)))).ToList();

            return result;
        }
        private bool IsValidFormat(string isbn)
        {
            return _isbnFormatDash.IsMatch(isbn) || _isbnFormatNoDash.IsMatch(isbn);
        }
    }
}