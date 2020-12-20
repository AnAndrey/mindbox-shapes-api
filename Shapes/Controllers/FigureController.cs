using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly ShapeContext _shapes;

        public FigureController(ShapeContext shapes)
        {
            _shapes = shapes;
        }

        [HttpPost]
        public IActionResult Add(ShapeModel model)
        {
            ShapeDto dto;
            switch (model.ShapeType.ToUpperInvariant())
            {
                case ShapesTypes.Circle:
                    dto = new ShapeDto
                    {
                        ShapeType = ShapesTypes.Circle,
                        Metadata = JsonConvert.SerializeObject(model.Metadata)
                    };
                    break;
                case ShapesTypes.Triangle:
                    dto = new ShapeDto
                    {
                        ShapeType = ShapesTypes.Circle,
                        Metadata = JsonConvert.SerializeObject(model.Metadata)
                    };
                    break;
                case ShapesTypes.Rectangle:
                    dto = new ShapeDto
                    {
                        ShapeType = ShapesTypes.Circle,
                        Metadata = JsonConvert.SerializeObject(model.Metadata)
                    };
                    break;
                default:
                    return StatusCode(StatusCodes.Status400BadRequest, model);
            }

            var r = _shapes.Add(dto);
            _shapes.SaveChanges();

            model.Id = r.Entity.Id;
            return CreatedAtAction(nameof(Add), model);
        }

        [HttpGet("{id}")]
        public IActionResult GetSquare(int id)
        {
            var dto = _shapes.Find<ShapeDto>(id);

            SquareResultModel model = null;

            switch (dto.ShapeType)
            {
                case ShapesTypes.Circle:
                    model = new SquareResultModel
                    {
                        ShapeType = ShapesTypes.Circle,
                        Square = JsonConvert.DeserializeObject<Circle>(dto.Metadata).Square.ToString("F")
                    };
                    break;
                case ShapesTypes.Triangle:
                    model = new SquareResultModel
                    {
                        ShapeType = ShapesTypes.Circle,
                        Square = JsonConvert.DeserializeObject<Triangle>(dto.Metadata).Square.ToString("F")
                    };
                    break;
                case ShapesTypes.Rectangle:
                    model = new SquareResultModel
                    {
                        ShapeType = ShapesTypes.Circle,
                        Square = JsonConvert.DeserializeObject<Rectangle>(dto.Metadata).Square.ToString("F")
                    };
                    break;
            }

            return Ok(model);
        }
    }
}
