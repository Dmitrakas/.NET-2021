using System;
using System.Threading;

namespace Task_6_1
{
    public class Program
    {
        public static void Main()
        {
            using var cache = new Cache(3);
            cache.Set("abc", 1);
            cache.Set("bcd", 2);
            cache.Set("cde", 3);
            cache.Set("def", 4);
            Console.WriteLine(cache.Count);
            cache.Remove("def");
            Console.WriteLine(cache.Count);
            Thread.Sleep(5000);
            var x = cache.Get("abc");
            Thread.Sleep(4000);
            var y = cache.Get("bcd");
            Thread.Sleep(5000);
            Console.WriteLine(cache.Count);
        }
    }
}