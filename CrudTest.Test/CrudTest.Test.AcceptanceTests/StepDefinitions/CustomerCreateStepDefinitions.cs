using CrudTest.Core.Contracts.DTOs;
using CrudTest.Core.Contracts.DTOs.Customer;
using CrudTest.Test.SharedMocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerCreateStepDefinitions
    {
        private CustomerCreateDTO _customerCreateDTO;
        private ObjectResult _result;

        [Given(@"the customer data \((.*),(.*),(.*),(.*),(.*),(.*)\)")]
        public void GivenTheCustomerData(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, ulong bankAccountNumber)
        {
            _customerCreateDTO = new CustomerCreateDTO
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phoneNumber,
                BankAccountNumber = bankAccountNumber
            };
        }

        [When(@"createing a new customer using this data")]
        public void WhenCreateingANewCustomerUsingThisData()
        {
            _result = (ObjectResult)MockCustomerController.CustomerController.CreateCustomer(_customerCreateDTO).Result;
        }

        [Then(@"the action should return status code \((.*)\)")]
        public void ThenTheActionShouldReturnStatusCode(int statusCode)
        {
            Assert.NotNull(_result);
            Assert.Equal(statusCode, _result.StatusCode);

            if (statusCode == StatusCodes.Status201Created)
            {
                Assert.IsAssignableFrom<CreatedAtRouteResult>(_result);
                Assert.Equal("CustomerById", (_result as CreatedAtRouteResult)!.RouteName);
            }
            else
            {
                Assert.IsAssignableFrom<ErrorDTO>(_result.Value);
            }
        }
    }
}
