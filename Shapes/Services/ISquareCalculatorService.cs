using Shapes.Shapes;

namespace Shapes.Services
{
    public interface ISquareCalculatorService
    {
        double CalculateSquare(Circle circle);

        double CalculateSquare(Triangle triangle);

        double CalculateSquare(Rectangle rectangle);
    }
}
