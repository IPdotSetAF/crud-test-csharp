using CrudTest.Bussiness.Contracts.DTOs;
using CrudTest.Bussiness.Contracts.DTOs.Customer;
using CrudTest.Bussiness.Contracts.Utils;
using CrudTest.Test.SharedMocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerUpdateStepDefinitions
    {
        private Guid _id;
        private CustomerUpdateDTO? _customerUpdateDTO;
        private ObjectResult? _result;

        [Given(@"the Id of an existing customer and data \((.*),(.*),(.*),(.*)\)")]
        public void GivenTheIdOfAnExistingCustomerAndData(int idSeed, string email, string phoneNumber, ulong bankAccountNumber)
        {
            _id = GuidUtil.SeededGuid(idSeed);
            _customerUpdateDTO = new CustomerUpdateDTO
            {
                Email = email,
                PhoneNumber = phoneNumber,
                BankAccountNumber = bankAccountNumber
            };
        }

        [When(@"updateing this customer using the data")]
        public void WhenUpdateingThisCustomerUsingTheData()
        {
            try
            {
                _result = (ObjectResult)MockCustomerController.CustomerController.UpdateCustomer(_id, _customerUpdateDTO).Result;
            }
            catch (InvalidCastException)
            {
                _result = null;
            }
        }

        [Then(@"the action should return \((.*)\)")]
        public void ThenTheActionShouldReturn(int statusCode)
        {
            if (statusCode == StatusCodes.Status204NoContent)
            {
                Assert.Null(_result);
            }
            else
            {
                if (_result != null)
                {
                    Assert.Equal(statusCode, _result.StatusCode);
                    Assert.IsAssignableFrom<ErrorDTO>(_result.Value);
                }
            }
        }
    }
}
