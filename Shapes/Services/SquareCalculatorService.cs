using System;
using Shapes.Shapes;

namespace Shapes.Services
{
    public class SquareCalculatorService : ISquareCalculatorService
    {
        public decimal CalculateCircleSquare(Circle circle)
        {
            return (decimal) Math.PI * circle.Radius * circle.Radius;
        }
    }
}
