using System;
using System.Collections.Generic;
using System.IO;

namespace Task_9_1
{
    public class FileReader
    {
        private readonly string _fullPath;

        public FileReader(string fileName)
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

        public List<VacationRecord> Read()
        {
            var list = new List<VacationRecord>();
            var lineNumber = 1;
            foreach (var line in File.ReadLines(_fullPath))
            {
                try
                {
                    list.Add(VacationRecord.Parse(line));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{lineNumber}: {e.Message}");
                }

                lineNumber++;
            }

            return list;
        }
    }
}