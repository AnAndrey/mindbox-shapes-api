namespace Shapes.Shapes
{
    public class Circle : Shape
    {
        public decimal Radius { get; set; }
        
        public override decimal Square => CalculatorService.CalculateCircleSquare(this);
    }
}
