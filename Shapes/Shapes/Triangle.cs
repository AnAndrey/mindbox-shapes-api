using System.Text.Json.Serialization;

namespace Shapes.Shapes
{
    public class Triangle : Shape
    {
        public double Side1 { get; set; }

        public double Side2 { get; set; }

        public double Side3 { get; set; }

        public Triangle()
        {
        }

        public Triangle(int id, double side1, double side2, double side3) : base(id)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        [JsonIgnore]
        public override double Square => SquareService.CalculateSquare(this);
    }
}
