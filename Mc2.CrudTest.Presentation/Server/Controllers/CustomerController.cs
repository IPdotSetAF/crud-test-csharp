using AutoMapper;
using Contracts;
using DTOs;
using DTOs.Customer;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApplicationControllerBase
    {
        public CustomerController(IRepositoryManager repository, IMapper mapper) : base(repository, mapper)
        {
        }


        [HttpGet("GetCustomersByUser")]
        public async Task<IActionResult> GetAllCustomersForUser()
        {
            IEnumerable<Customer> customers = await Repository.Customer.GetAllCustomersAsync(false);

            IEnumerable<CustomerGetDTO> customerDTOs = Mapper.Map<IEnumerable<CustomerGetDTO>>(customers);

            return Ok(customerDTOs);
        }

        [HttpGet("CustomerById/{customerId}", Name = "CustomerById")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            Customer customers = await Repository.Customer.GetCustomerAsync(customerId, false);

            if (customers == null)
                return NotFound(new ErrorDTO(NotFound().StatusCode, "Customer does not exist"));

            CustomerGetDTO customerDto = Mapper.Map<CustomerGetDTO>(customers);

            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDto)
        {
            if (customerCreateDto == null)
                return BadRequest(new ErrorDTO(BadRequest().StatusCode, "Customer Dto for creation is null."));

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            Customer customer = Mapper.Map<Customer>(customerCreateDto);

            Repository.Customer.CreateCustomer(customer);
            await Repository.SaveAsync();

            CustomerGetDTO customerToReturn = Mapper.Map<CustomerGetDTO>(customer);

            return CreatedAtRoute("CustomerById", new { customerId = customerToReturn.Id }, customerToReturn);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid customerId, [FromBody] CustomerUpdateDTO customerUpdateDto)
        {
            if (customerUpdateDto == null)
                return BadRequest(new ErrorDTO(BadRequest().StatusCode, "Customer Dto for update is null."));

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            Customer customer = await Repository.Customer.GetCustomerAsync(customerId, true);

            if (customer == null)
                return NotFound(new ErrorDTO(NotFound().StatusCode, $"Customer with Id: {customerId} does not exist."));

            Mapper.Map(customerUpdateDto, customer);
            await Repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid customerId)
        {
            Customer customer = await Repository.Customer.GetCustomerAsync(customerId, false);

            if (customer == null)
                return NotFound(new ErrorDTO(NotFound().StatusCode, "Customer does not exist"));

            Repository.Customer.DeleteCustomer(customer);
            await Repository.SaveAsync();

            return NoContent();
        }
    }
}
