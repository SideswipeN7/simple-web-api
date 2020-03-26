using AutoMapper;
using SimpleApp.DTO;
using SimpleApp.Models;

namespace SimpleApp.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DtoCreateProduct, Product>();
            CreateMap<DtoUpdateProduct, Product>();
            CreateMap<Product, DtoProduct>();
        }
    }
}