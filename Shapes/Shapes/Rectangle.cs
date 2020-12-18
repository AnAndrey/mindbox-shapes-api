namespace Shapes.Shapes
{
    public class Rectangle : Shape
    {
        public double Side1 { get; set; }

        public double Side2 { get; set; }

        public Rectangle(int id, double side1, double side2) : base(id)
        {
            Side1 = side1;
            Side2 = side2;
        }

        public override double Square => SquareService.CalculateSquare(this);
    }
}
