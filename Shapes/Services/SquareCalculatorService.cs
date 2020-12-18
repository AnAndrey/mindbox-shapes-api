using System;
using Shapes.Shapes;

namespace Shapes.Services
{
    public class SquareCalculatorService : ISquareCalculatorService
    {
        public double CalculateSquare(Circle circle)
        {
            var s = Math.PI * circle.Radius * circle.Radius;
            return s;
        }

        public double CalculateSquare(Triangle t)
        {
            var p = (t.Side1 + t.Side2 + t.Side3) / 2;
            var s = Math.Sqrt(p * (p - t.Side1) * (p - t.Side2) * (p - t.Side3));
            return s;
        }

        public double CalculateSquare(Rectangle rectangle)
        {
            var s = rectangle.Side1 * rectangle.Side2;
            return s;
        }
    }
}
