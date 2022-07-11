using AutoMapper;
using Net6JwtApp.Back.Core.Application.Dtos;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
