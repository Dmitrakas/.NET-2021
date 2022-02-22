using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Task_7_2
{
    public class DataReader
    {
        private readonly string _fullPath;

        public DataReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            _fullPath = Path.GetFullPath(fileName);

            if (!File.Exists(_fullPath))
            {
                throw new FileNotFoundException("File Not Found", _fullPath);
            }
        }

        public List<Item> Read()
        {
            var culture = new CultureInfo("en-US");
            return File.ReadLines(_fullPath)
                .AsParallel()
                .Select(line => line.Split(','))
                .Select(parts => new Item(parts[0],
                    new Point(double.Parse(parts[1], culture), double.Parse(parts[2], culture))))
                .ToList();
        }
    }
}