using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task_7_1
{
    public class DataWriter
    {
        private readonly string _fullPath;

        public DataWriter(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty.", nameof(fileName));
            }

            _fullPath = Path.GetFullPath(fileName);
        }

        public void Write(IEnumerable<Person> data)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(_fullPath, json);
        }
    }
}