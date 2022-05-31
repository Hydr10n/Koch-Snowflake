using System;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace Hydr10n
{
    public static class KochSnowflakeGenerator
    {
        public static PointCollection Generate(uint repeatCount, double sideLength, Point translation)
        {
            var cos30 = Math.Cos(Math.PI / 6);

            var points = new PointCollection();

            double x = sideLength / 2, y = sideLength * cos30 / 2;
            points.Add(new Point(translation.X, y + translation.Y));
            points.Add(new Point(x + translation.X, -y + translation.Y));
            points.Add(new Point(-x + translation.X, -y + translation.Y));

            for (uint count = 0; count < repeatCount; count++)
            {
                var pointCount = points.Count;
                for (int i = 0, j = 0; i < pointCount; i++, j++)
                {
                    Point point = points[j], point1 = points[(j + 1) % points.Count];

                    var displacement = new Point(point1.X - point.X, point1.Y - point.Y);
                    var normal = new Point(-displacement.Y / 3 * cos30, displacement.X / 3 * cos30);

                    points.Insert(++j, new Point(point.X + displacement.X / 3, point.Y + displacement.Y / 3));
                    points.Insert(++j, new Point(point.X + displacement.X / 2 + normal.X, point.Y + displacement.Y / 2 + normal.Y));
                    points.Insert(++j, new Point(point.X + displacement.X / 3 * 2, point.Y + displacement.Y / 3 * 2));
                }
            }

            return points;
        }
    }
}
