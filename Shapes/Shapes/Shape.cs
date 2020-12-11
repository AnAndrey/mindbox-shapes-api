using Shapes.Services;

namespace Shapes.Shapes
{
    public abstract class Shape
    {
        protected readonly ISquareCalculatorService CalculatorService = new SquareCalculatorService();

        public int Id { get; set; }

        public abstract decimal Square { get; }
    }
}
