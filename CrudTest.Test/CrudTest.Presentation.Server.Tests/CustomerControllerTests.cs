using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudTest.Core.Contracts.DTOs.Customer;
using CrudTest.Core.Contracts.DTOs;
using CrudTest.Core.Services;
using CrudTest.Test.SharedMocks;
using CrudTest.Presentation.Server.Controllers;
using CrudTest.Core.Contracts.Utils;

namespace CrudTest.Test.XUnitTests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void WhenGettingAllCustomers_ThenAllCustomersReturns()
        {
            var result = MockCustomerController.CustomerController.GetAllCustomers().Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<CustomerGetDTO>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<CustomerGetDTO>);
        }

        [Fact]
        public void GivenAnIdOfAnExistingCustomer_WhenGettingCustomerById_ThenCustomerReturns()
        {
            var id = GuidUtil.SeededGuid(1);

            var result = MockCustomerController.CustomerController.GetCustomer(id).Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal((result.Value as CustomerGetDTO).Id, id);
            Assert.IsAssignableFrom<CustomerGetDTO>(result.Value);
        }

        [Theory]
        [InlineData("mahdi", "nazari", "2012-1-20", "989387016860", "test@test.com", 1212121212121212, true)]
        [InlineData("mahdi", "nazari", "2012-1-20", "+989387016860", "ipdotsetaf.work@gmail.com", 1212121212121212, false)]
        [InlineData("mahdi", "nazari", "2012-1-20", "989016860", "test@test.com", 1212121212121212, false)]
        [InlineData("Ali", "Nazari", "2012-1-20", "989387016860", "test@test.com", 1212121212121212, false)]
        public void GivenValidRequest_WhenCreatingCustomer_ThenCreatedReturns(string? firstName, string? lastName, DateTime dateOfBirth, string phoneNumber, string? email, ulong bankAccNumber, bool isValid)
        {
            var customer = new CustomerCreateDTO
            {
                FirstName = firstName,
                LastName = lastName,
                BankAccountNumber = bankAccNumber,
                PhoneNumber = phoneNumber,
                Email = email,
                DateOfBirth = dateOfBirth
            };

            var result = MockCustomerController.CustomerController.CreateCustomer(customer).Result as ObjectResult;

            Assert.NotNull(result);
            if (isValid)
            {
                Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
                Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
                Assert.Equal("CustomerById", (result as CreatedAtRouteResult)!.RouteName);
            }
            else
            {
                Assert.IsAssignableFrom<ErrorDTO>(result.Value);
                Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            }
        }

        [Theory]
        [InlineData(1, "+989387016860", 1212121212121212, true)]
        [InlineData(1, "989016860", 1212121212121212, false)]
        [InlineData(5, "989387016860", 1212121212121212, false)]
        public void GivenValidRequest_WhenUpdateingCustomer_ThenNothingReturns(int guidSeed, string phoneNumber, ulong bankAccNumber, bool isValid)
        {
            var customer = new CustomerUpdateDTO
            {
                BankAccountNumber = bankAccNumber,
                PhoneNumber = phoneNumber
            };

            var result = MockCustomerController.CustomerController.UpdateCustomer(GuidUtil.SeededGuid(guidSeed), customer).Result as ObjectResult;

            if (isValid)
            {
                Assert.Null(result);
            }
            else
            {
                Assert.IsAssignableFrom<ErrorDTO>(result.Value);
            }
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(5, false)]
        public void GivenAnIdOfAnExistingCustomer_WhenDeletingCustomer_ThenNothingReturns(int guidSeed, bool isValid)
        {
            var result = MockCustomerController.CustomerController.DeleteCustomer(GuidUtil.SeededGuid(guidSeed)).Result as ObjectResult;

            if (isValid)
            {
                Assert.Null(result);
            }
            else
            {
                Assert.IsAssignableFrom<NotFoundObjectResult>(result);
            }
        }
    }
}
