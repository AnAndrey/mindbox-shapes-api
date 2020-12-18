using Shapes.Services;

namespace Shapes.Shapes
{
    public abstract class Shape
    {
        protected readonly ISquareCalculatorService SquareService = new SquareCalculatorService();

        protected Shape(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public abstract double Square { get; }
    }
}
