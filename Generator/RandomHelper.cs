using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Generator
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

        public static List<Point> GetRandomPoints(int count, int max, Point? except)
        {
            var points = new List<Point>();

            while (points.Count() < count)
            {
                var newPoints = GetRandomPoints(count - points.Count, max);
                points.AddRange(newPoints);
                points = points.Distinct().ToList();
                if (except.HasValue)
                {
                    points.RemoveAll(x => x.Equals(except.Value));
                }
            }

            return points;
        }

        public static List<Point> GetRandomPoints(int count, int max)
        {
            var points = new List<Point>();
            for (var i = 0; i < count; i++)
            {
                points.Add(new Point(Random.Next(max), Random.Next(max)));
            }

            return points;
        }
    }
}