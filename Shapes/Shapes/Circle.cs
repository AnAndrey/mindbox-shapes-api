using System.Text.Json.Serialization;

namespace Shapes.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle()
        {
        }

        public Circle(int id, double radius) : base(id)
        {
            Radius = radius;
        }

        [JsonIgnore]
        public override double Square => SquareService.CalculateSquare(this);
    }
}
