using CrudTest.Core.Contracts.DTOs;
using CrudTest.Core.Contracts.DTOs.Customer;
using CrudTest.Core.Contracts.Utils;
using CrudTest.Test.SharedMocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerGetByIdStepDefinitions
    {
        private ObjectResult _result;
        private Guid _id;

        [Given(@"the Id \((.*)\) of a customer")]
        public void GivenTheIdOfACustomer(int idSeed)
        {
            _id = GuidUtil.SeededGuid(idSeed);
        }

        [When(@"I request to get the customer by that Id")]
        public void WhenIRequestToGetTheCustomerByThatId()
        {
            _result = (ObjectResult)MockCustomerController.CustomerController.GetCustomer(_id).Result;
        }

        [Then(@"the action returns customer with Status code \((.*)\)")]
        public void ThenTheActionReturnsCustomerWithStatusCode(int statusCode)
        {
            Assert.NotNull(_result);
            Assert.Equal(statusCode, _result.StatusCode);
            if (statusCode == 200)
            {
                Assert.Equal((_result.Value as CustomerGetDTO).Id, _id);
                Assert.IsAssignableFrom<CustomerGetDTO>(_result.Value);
            }
            else
            {
                Assert.IsAssignableFrom<ErrorDTO>(_result.Value);
            }
        }
    }
}
