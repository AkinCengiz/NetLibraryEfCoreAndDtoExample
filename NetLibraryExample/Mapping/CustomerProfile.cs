using AutoMapper;
using NetLibraryExample.Models.DTOs;
using NetLibraryExample.Models.ORM;

namespace NetLibraryExample.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
    }
}
