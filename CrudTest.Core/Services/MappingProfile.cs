using AutoMapper;
using CrudTest.Bussiness.Contracts.DTOs.Customer;
using CrudTest.Bussiness.Domain.Entities;
using CrudTest.Bussiness.Domain.Entities.ValueObjects;

namespace CrudTest.Bussiness.Services
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
                .ForMember(c => c.Person, options => options.MapFrom(c => new Person(c.FirstName, c.LastName, DateOnly.FromDateTime(c.DateOfBirth))));
            CreateMap<Customer, CustomerGetDTO>()
                .ForMember(c => c.Email, options => options.MapFrom(c => c.Email.Value))
                .ForMember(c => c.BankAccountNumber, options => options.MapFrom(c => c.BankAccountNumber.Value))
                .ForMember(c => c.PhoneNumber, options => options.MapFrom(c => c.PhoneNumber.Value))
                .ForMember(c => c.DateOfBirth, options => options.MapFrom(c => c.Person.DateOfBirth.ToDateTime(TimeOnly.MinValue)))
                .ForMember(c => c.FirstName, options => options.MapFrom(c => c.Person.FirstName))
                .ForMember(c => c.LastName, options => options.MapFrom(c => c.Person.LastName));
        }
    }
}
