using AutoMapper;
using Newtonsoft.Json;
using Shapes.Shapes;

namespace Shapes.DataAccess
{
    public class ShapesRepository : IShapesRepository
    {
        private readonly ShapeContext _context;
        private readonly IMapper _mapper;

        public ShapesRepository(ShapeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Shape GetShape(int id)
        {
            Shape result = null;

            var dto = _context.Shapes.Find(id);
            if (dto != null)
                result = (Shape) JsonConvert.DeserializeObject(dto.Metadata,
                    new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All});

            return result;
        }

        public int CreateShape(Shape shape)
        {
            var dto = _mapper.Map<ShapeDto>(shape);

            var entity = _context.Shapes.Add(dto);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public void DeleteAllShapes()
        {
            _context.RemoveRange(_context.Shapes);
            _context.SaveChanges();
        }
    }
}
