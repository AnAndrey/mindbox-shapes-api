using System.Text.Json.Serialization;
using Shapes.Services;

namespace Shapes.Shapes
{
    public abstract class Shape
    {
        protected readonly ISquareCalculatorService SquareService = new SquareCalculatorService();

        protected Shape()
        {
        }

        protected Shape(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        [JsonIgnore]
        public abstract double Square { get; }
    }
}
