using System.Collections.Generic;
using System.Dynamic;
using AutoMapper;
using Newtonsoft.Json;
using Shapes.DataAccess;
using Shapes.Models;
using Shapes.Shapes;

namespace Shapes.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExpandoObject, Circle>()
                .ForMember(d => d.Radius, o => o.MapFrom(s => ((IDictionary<string, object>)s)["radius"]));
            CreateMap<ExpandoObject, Triangle>()
                .ForMember(d => d.Side1, o => o.MapFrom(s => ((IDictionary<string, object>)s)["side1"]))
                .ForMember(d => d.Side2, o => o.MapFrom(s => ((IDictionary<string, object>)s)["side2"]))
                .ForMember(d => d.Side3, o => o.MapFrom(s => ((IDictionary<string, object>)s)["side3"]));
            CreateMap<ExpandoObject, Rectangle>()
                .ForMember(d => d.Side1, o => o.MapFrom(s => ((IDictionary<string, object>)s)["side1"]))
                .ForMember(d => d.Side2, o => o.MapFrom(s => ((IDictionary<string, object>)s)["side2"]));

            CreateMap<Shape, ShapeDto>()
                .ForMember(dest => dest.ShapeType, opt => opt.MapFrom(src => src.GetType().Name))
                .ForMember(dest => dest.Metadata,
                    opt => opt.MapFrom(src => JsonConvert.SerializeObject(src,
                        new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All})));

            CreateMap<Shape, SquareResultModel>()
                .ForMember(dest => dest.ShapeType, opt => opt.MapFrom(src => src.GetType().Name))
                .ForMember(dest => dest.Square, opt => opt.MapFrom(src => src.Square.ToString("F")));
        }
    }
}
