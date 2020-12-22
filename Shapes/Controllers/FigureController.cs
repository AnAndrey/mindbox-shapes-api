using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shapes.Common;
using Shapes.DataAccess;
using Shapes.Models;
using Shapes.Shapes;

namespace Shapes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ShapesRepository _repository;

        public FigureController(IMapper mapper, ShapesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add(ShapeModel model)
        {
            Shape shape;

            switch (model.ShapeType.ToUpperInvariant())
            {
                case ShapesTypes.Circle:
                    shape = _mapper.Map<Circle>(model.Metadata);
                    break;
                case ShapesTypes.Triangle:
                    shape = _mapper.Map<Triangle>(model.Metadata);
                    break;
                case ShapesTypes.Rectangle:
                    shape = _mapper.Map<Rectangle>(model.Metadata);
                    break;
                default:
                    return BadRequest(ModelState);
            }

            int result = _repository.CreateShape(shape);
            model.Id = result;
            return CreatedAtAction(nameof(Add), model);
        }

        [HttpGet("{id}")]
        public IActionResult GetSquare(int id)
        {
            var shape = _repository.GetShape(id);

            if (shape == null)
                return NotFound();

            var model = _mapper.Map<SquareResultModel>(shape);

            return Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            _repository.DeleteAllShapes();
            return NoContent();
        }
    }
}
