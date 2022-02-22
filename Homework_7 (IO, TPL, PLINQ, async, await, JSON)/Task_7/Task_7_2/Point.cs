using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_7_2
{
    public record Point(double X, double Y)
    {
        public double DistanceTo(Point other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var dx = other.X - X;
            var dy = other.Y - Y;
            return dx * dx + dy * dy;
        }

        public static async IAsyncEnumerable<Point> Produce(uint n)
        {
            Random random = new();
            for (var i = 1; i <= n; i++)
            {
                yield return new Point(random.NextDouble() * 10, random.NextDouble() * 10);
                await Task.Delay(1000);
            }
        }
    }
}