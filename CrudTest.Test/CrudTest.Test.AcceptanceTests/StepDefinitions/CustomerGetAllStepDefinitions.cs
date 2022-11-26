using CrudTest.Bussiness.Contracts.DTOs.Customer;
using CrudTest.Test.SharedMocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerGetAllStepDefinitions
    {
        private ObjectResult? _result;

        [When(@"I request to get all customers")]
        public void WhenIRequestToGetAllCustomers()
        {
            _result = (ObjectResult)MockCustomerController.CustomerController.GetAllCustomers().Result;
        }

        [Then(@"the action should return a list of all customers with Status code (.*)")]
        public void ThenTheActionShouldReturnAListOfAllCustomersWithStatusCode(int statusCode)
        {
            Assert.NotNull(_result);
            if (_result != null)
            {
                Assert.Equal(statusCode, _result.StatusCode);
                Assert.IsAssignableFrom<IEnumerable<CustomerGetDTO>>(_result.Value);
                Assert.NotEmpty(_result.Value as IEnumerable<CustomerGetDTO>);
            }
        }
    }
}
