using AutoMapper;
using NetLibraryExample.Models.DTOs;
using NetLibraryExample.Models.ORM;

namespace NetLibraryExample.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
