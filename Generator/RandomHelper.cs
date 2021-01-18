using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Generator
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

        public static List<Point> GetRandomPoints(int count, int max)
        {
            var points = new List<Point>();
            for (var i = 0; i < count; i++)
            {
                points.Add(new Point(Random.Next(max), Random.Next(max)));
            }

            var distinct = points.Distinct().ToList();

            while (distinct.Count() < count)
            {
                var newPoints = GetRandomPoints(count - distinct.Count, max);
                points.AddRange(newPoints);
                distinct = points.Distinct().ToList();
            }

            return distinct;
        }
    }
}