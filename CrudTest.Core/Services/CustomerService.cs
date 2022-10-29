﻿using CrudTest.Core.Domain.Entities;
using CrudTest.Core.Domain.RepositoryInterfaces;
using CrudTest.Core.Contracts.DTOs.Customer;
using CrudTest.Core.Services.Abstractions;
using CrudTest.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudTest.Core.Domain.Entities.ValueObjects;
using AutoMapper;

namespace CrudTest.Core.Services
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(IRepositoryManager repositoryManager) : base(repositoryManager){}

        public async Task<IEnumerable<CustomerGetDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var customers = await RepositoryManager.CustomerRepository.GetAllAsync(false, cancellationToken);

            var customersDto = Mapper.Map<IEnumerable<CustomerGetDTO>>(customers);

            return (customersDto);
        }

        public async Task<CustomerGetDTO> GetByIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            var customer = await RepositoryManager.CustomerRepository.GetByIdAsync(customerId, false, cancellationToken);

            if (customer is null)
                throw new CustomerNotFoundException(customerId);

            var customerDto = Mapper.Map<CustomerGetDTO>(customer);

            return (customerDto);
        }

        public async Task<CustomerGetDTO> CreateAsync(CustomerCreateDTO customerCreateDTO, CancellationToken cancellationToken = default)
        {
            try
            {
                var customer = Mapper.Map<Customer>(customerCreateDTO);

                if (await RepositoryManager.CustomerRepository.CustomerExists(customer))
                    throw new CustomerExistsException(customer.FirstName, customer.LastName, customer.DateOfBirth);

                if (await RepositoryManager.CustomerRepository.EmailExists(customer.Email))
                    throw new CustomerExistsException(customer.Email);

                RepositoryManager.CustomerRepository.Insert(customer);

                await RepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return Mapper.Map<CustomerGetDTO>(customer);
            }
            catch (AutoMapperMappingException e)
            {
                throw e.InnerException;
            }
        }

        public async Task UpdateAsync(Guid customerId, CustomerUpdateDTO customerUpdateDTO, CancellationToken cancellationToken = default)
        {
            try
            {
                var customer = await RepositoryManager.CustomerRepository.GetByIdAsync(customerId, true, cancellationToken);

                if (customer is null)
                    throw new CustomerNotFoundException(customerId);

                var email = new Email(customerUpdateDTO.Email);

                if (await RepositoryManager.CustomerRepository.EmailExists(email))
                    throw new CustomerExistsException(email);

                Mapper.Map(customerUpdateDTO, customer);

                await RepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (AutoMapperMappingException e)
            {
                throw e.InnerException;
            }
        }

        public async Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            var customer = await RepositoryManager.CustomerRepository.GetByIdAsync(customerId, false, cancellationToken);

            if (customer is null)
                throw new CustomerNotFoundException(customerId);

            RepositoryManager.CustomerRepository.Remove(customer);

            await RepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
