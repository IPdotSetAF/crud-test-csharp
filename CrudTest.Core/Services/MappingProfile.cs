using AutoMapper;
using CrudTest.Core.Contracts.DTOs.Customer;
using CrudTest.Core.Domain.Entities;
using CrudTest.Core.Domain.Entities.ValueObjects;

namespace CrudTest.Core.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerUpdateDTO, Customer>()
                .ForMember(c => c.Email, options => options.MapFrom(c => new Email(c.Email)))
                .ForMember(c => c.BankAccountNumber, options => options.MapFrom(c => new BankAccountNumber(c.BankAccountNumber)))
                .ForMember(c => c.PhoneNumber, options => options.MapFrom(c => new PhoneNumber(c.PhoneNumber)));
            CreateMap<CustomerCreateDTO, Customer>()
                .ForMember(c => c.Email, options => options.MapFrom(c => new Email(c.Email)))
                .ForMember(c => c.BankAccountNumber, options => options.MapFrom(c => new BankAccountNumber(c.BankAccountNumber)))
                .ForMember(c => c.PhoneNumber, options => options.MapFrom(c => new PhoneNumber(c.PhoneNumber)))
                .ForMember(c => c.DateOfBirth, o => o.MapFrom(o => DateOnly.FromDateTime(o.DateOfBirth)));
            CreateMap<Customer, CustomerGetDTO>()
                .ForMember(c => c.Email, options => options.MapFrom(c => c.Email.Value))
                .ForMember(c => c.BankAccountNumber, options => options.MapFrom(c => c.BankAccountNumber.Value))
                .ForMember(c => c.PhoneNumber, options => options.MapFrom(c => c.PhoneNumber.Value))
                .ForMember(c => c.DateOfBirth, o => o.MapFrom(o => o.DateOfBirth.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
