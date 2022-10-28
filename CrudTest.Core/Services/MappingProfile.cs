using AutoMapper;
using CrudTest.Core.Contracts.DTOs.Customer;
using CrudTest.Core.Domain.Entities;

namespace CrudTest.Core.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerUpdateDTO, Customer>();
            CreateMap<CustomerCreateDTO, Customer>()
                .ForMember(c => c.DateOfBirth, o => o.MapFrom(o => DateOnly.FromDateTime(o.DateOfBirth)));
            CreateMap<Customer, CustomerGetDTO>()
                .ForMember(c => c.DateOfBirth, o => o.MapFrom(o => o.DateOfBirth.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
