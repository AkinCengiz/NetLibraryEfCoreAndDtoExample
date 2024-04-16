using AutoMapper;
using NetLibraryExample.Models.DTOs;
using NetLibraryExample.Models.ORM;

namespace NetLibraryExample.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
