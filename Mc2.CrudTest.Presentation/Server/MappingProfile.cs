using AutoMapper;
using DTOs.Customer;
using Entities.Models;
using System;

namespace Mc2.CrudTest.Presentation.Server
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
