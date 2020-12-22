using System;
using Shapes.Shapes;

namespace Shapes.DataAccess
{
    public interface IShapesRepository
    {
        Shape GetShape(int id);

        int CreateShape(Shape shape);

        void DeleteAllShapes();
    }
}
