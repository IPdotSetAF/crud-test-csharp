using System;
using TechTalk.SpecFlow;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerCreateStepDefinitions
    {
        [Given(@"the customer data \((.*),(.*),(.*),(.*),(.*),(.*)\)")]
        public void GivenTheCustomerData(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, ulong bankAccountNumber)
        {
            throw new PendingStepException();
        }

        [When(@"createing a new customer using this data")]
        public void WhenCreateingANewCustomerUsingThisData()
        {
            throw new PendingStepException();
        }

        [Then(@"the action should return status code \((.*)\)")]
        public void ThenTheActionShouldReturnStatusCode(int statusCode)
        {
            throw new PendingStepException();
        }
    }
}
