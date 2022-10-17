using AutoMapper;
using DTOs.Customer;
using Entities.Models;

namespace Mc2.CrudTest.Presentation.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerUpdateDTO, Customer>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<Customer, CustomerGetDTO>();
        }
    }
}
