using CrudTest.Core.Contracts.DTOs;
using CrudTest.Core.Contracts.DTOs.Customer;
using CrudTest.Core.Domain.Exceptions;
using CrudTest.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ApplicationControllerBase
    {
        public CustomerController(IServiceManager serviceManager) : base(serviceManager)
        {
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await ServiceManager.CustomerService.GetAllAsync());
        }

        [HttpGet("CustomerById/{customerId}", Name = "CustomerById")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            try
            {
                return Ok(await ServiceManager.CustomerService.GetByIdAsync(customerId));
            }
            catch (CustomerNotFoundException e)
            {
                return NotFound(new ErrorDTO(NotFound().StatusCode, e.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDto)
        {
            try
            {
                var customer = await ServiceManager.CustomerService.CreateAsync(customerCreateDto);

                return CreatedAtRoute("CustomerById", new { customerId = customer.Id }, customer);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO(BadRequest().StatusCode, e.Message));
            }
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid customerId, [FromBody] CustomerUpdateDTO customerUpdateDto)
        {
            //TODO: catch null body exception
            //TODO: catch data validation exceptions
            try
            {
                await ServiceManager.CustomerService.UpdateAsync(customerId, customerUpdateDto);
                return NoContent();
            }
            catch (CustomerNotFoundException e)
            {
                return NotFound(new ErrorDTO(NotFound().StatusCode, e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO(BadRequest().StatusCode, e.Message));
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid customerId)
        {
            try
            {
                await ServiceManager.CustomerService.DeleteAsync(customerId);
                return NoContent();
            }
            catch (CustomerNotFoundException e)
            {
                return NotFound(new ErrorDTO(NotFound().StatusCode, e.Message));
            }
        }
    }
}
