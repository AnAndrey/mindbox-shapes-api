namespace Shapes.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(int id, double radius) : base(id)
        {
            Radius = radius;
        }

        public override double Square => SquareService.CalculateSquare(this);
    }
}
