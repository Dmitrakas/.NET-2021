using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task_8_2
{
    public class SimpleBinder 
    {
        private static readonly SimpleBinder _instance = new();
        public static SimpleBinder GetInstance() => _instance;

        private SimpleBinder()
        {
        }

        public T Bind<T>(Dictionary<string, string> source) where T : new()
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var dest = new T();
            var typeDest = dest.GetType();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var dict = new Dictionary<string, string>();
            foreach (var item in source)
            {
                dict[item.Key.ToLower()] = item.Value;
            }

            foreach (var fieldDest in typeDest.GetFields(flags))
            {
                var fieldName = fieldDest.Name.ToLower();

                if (dict.ContainsKey(fieldName))
                {
                    try 
                    {
                        object value = fieldDest.FieldType.FullName switch
                        {
                            "System.Int32" => int.Parse(dict[fieldName]),
                            "System.Double" => double.Parse(dict[fieldName]),
                            "System.String" => dict[fieldName],
                            _ => null
                        };

                        fieldDest.SetValue(dest, value);
                    }
                    catch 
                    { 
                    }
                }
            }

            foreach (var propDest in typeDest.GetProperties(flags))
            {
                if (!propDest.CanRead || !propDest.CanWrite)
                {
                    continue;
                }

                var propName = propDest.Name.ToLower();

                if (dict.ContainsKey(propName))
                {
                    try
                    {
                        object value = propDest.PropertyType.FullName switch
                        {
                            "System.Int32" => int.Parse(dict[propName]),
                            "System.Double" => double.Parse(dict[propName]),
                            "System.String" => dict[propName],
                            _ => null
                        };

                        propDest.SetValue(dest, value);
                    }
                    catch
                    {
                    }
                }
            }

            return dest;
        }
    }
}