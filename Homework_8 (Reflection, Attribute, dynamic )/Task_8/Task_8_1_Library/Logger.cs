using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Task_8_1_Library
{
    public class Logger
    {
        private readonly string _jsonName;

        public Logger(string jsonName)
        {
            _jsonName = jsonName ?? throw new ArgumentNullException(nameof(jsonName));
        }

        public void Track<T>(T obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var type = obj.GetType();
            var trackingEntityAttrib = type.GetCustomAttribute<TrackingEntity>();
            if (trackingEntityAttrib is null)
            {
                return;
            }

            Dictionary<string, string> dict = new();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (var field in type.GetFields(flags))
            {
                var trackingPropertyAttrib = (TrackingProperty)field.GetCustomAttribute(typeof(TrackingProperty));
                if (trackingPropertyAttrib == null)
                {
                    continue;
                }

                var fieldName = !string.IsNullOrEmpty(trackingPropertyAttrib.PropertyName) ? trackingPropertyAttrib.PropertyName : field.Name;
                var fieldValue = field.GetValue(obj).ToString();

                dict.Add(fieldName, fieldValue);
            }

            foreach (var prop in type.GetProperties(flags))
            {
                if (!prop.CanRead)
                {
                    continue;
                }

                var trackingPropertyAttrib = (TrackingProperty)prop.GetCustomAttribute(typeof(TrackingProperty));
                if (trackingPropertyAttrib == null)
                {
                    continue;
                }

                var propName = !string.IsNullOrEmpty(trackingPropertyAttrib.PropertyName) ? trackingPropertyAttrib.PropertyName : prop.Name;
                var propValue = prop.GetValue(obj).ToString();

                dict.Add(propName, propValue);
            }

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var json = JsonSerializer.Serialize(dict, options);
            File.WriteAllText(_jsonName, json);

            Console.WriteLine("Done!");
        }
    }
}