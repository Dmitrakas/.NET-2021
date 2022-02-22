using System;
using System.Collections.Generic;
using System.IO;

namespace Task_7_1
{
    public class DataReader
    {
        private readonly string _fullPath;

        public DataReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty.", nameof(fileName));
            }

            _fullPath = Path.GetFullPath(fileName);

            if (!File.Exists(_fullPath))
            {
                throw new FileNotFoundException("File Not Found", _fullPath);
            }
        }

        public List<Vacation> Read()
        {
            var list = new List<Vacation>();
            var lineNumber = 1;
            foreach (var line in File.ReadLines(_fullPath))
            {
                try
                {
                    list.Add(Vacation.Parse(line));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"#{lineNumber}: {ex.Message}");
                }

                lineNumber++;
            }

            return list;
        }
    }
}