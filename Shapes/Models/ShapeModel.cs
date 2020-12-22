using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using Shapes.Common;

namespace Shapes.Models
{
    public class ShapeModel : IValidatableObject
    {
        public int? Id { get; set; }

        [Required]
        public string ShapeType { get; set; }

        [Required]
        public ExpandoObject Metadata { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var types = new[] { ShapesTypes.Circle, ShapesTypes.Triangle, ShapesTypes.Rectangle };
            if (!types.Contains(ShapeType, StringComparer.InvariantCultureIgnoreCase))
            {
                yield return new ValidationResult(
                    $"Invalid shape type: {ShapeType}",
                    new[] {nameof(ShapeType)});
            }
        }
    }
}
