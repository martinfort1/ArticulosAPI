using AutoMapper;
using ArticulosAPI.Modelos;
using ArticulosAPI.Modelos.DTOs;
namespace ArticulosAPI
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ArticulosDto, Articulos>();
                config.CreateMap<Articulos, ArticulosDto>();
            });
            return mappingConfig;
        }
    }
}
