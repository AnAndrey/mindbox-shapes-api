using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shapes.Models;
using Shapes.Shapes;

namespace Shapes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shapes = new List<Shape> {new Circle {Id = id, Radius = 3.33M}};
            var r = shapes.Select(s => new ShapeModel
                {Description = s.GetType().Name, Square = s.Square.ToString("F")});
            return Ok(r);
        }
    }
}
