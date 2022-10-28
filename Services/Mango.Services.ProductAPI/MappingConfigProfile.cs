using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;

namespace Mango.Services.ProductAPI
{
    public class MappingConfigProfile : Profile
    {
        public MappingConfigProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}