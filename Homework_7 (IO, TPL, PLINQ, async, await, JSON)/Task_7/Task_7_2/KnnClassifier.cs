using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_7_2
{
    public static class KnnClassifier
    {
        public static Item Classify(IEnumerable<Item> data, Point point, int k = 3)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (k <= 1)
            {
                throw new ArgumentException("Must be greater than 1", nameof(k));
            }

            var name = data.AsParallel()
                .Select(item => (item.Name, Distance: item.Point.DistanceTo(point)))
                .OrderBy(pair => pair.Distance)
                .Take(k)
                .GroupBy(pair => pair.Name)
                .Select(group => (group.Key, count: group.Count()))
                .OrderByDescending(pair => pair.count)
                .First().Key;

            return new Item(name, point);
        }
    }
}