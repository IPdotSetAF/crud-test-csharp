using CrudTest.Core.Contracts.DTOs;
using CrudTest.Core.Contracts.Utils;
using CrudTest.Test.SharedMocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechTalk.SpecFlow;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerDeleteStepDefinitions
    {
        private Guid _id;
        private ObjectResult _result;

        [Given(@"The Id \((.*)\) of a customer")]
        public void GivenTheIdOfACustomer(int idSeed)
        {
            _id = GuidUtil.SeededGuid(idSeed);
        }

        [When(@"sending delete request to action")]
        public void WhenSendingDeleteRequestToAction()
        {
            try
            {
                _result = (ObjectResult)MockCustomerController.CustomerController.DeleteCustomer(_id).Result;
            }
            catch (InvalidCastException)
            {
                _result = null;
            }
        }

        [Then(@"the action should return Status code \((.*)\)")]
        public void ThenTheActionShouldReturnStatusCode(int statusCode)
        {
            if (statusCode == StatusCodes.Status204NoContent)
            {
                Assert.Null(_result);
            }
            else
            {
                Assert.Equal(statusCode, _result.StatusCode);
                Assert.IsAssignableFrom<ErrorDTO>(_result.Value);
            }
        }
    }
}
