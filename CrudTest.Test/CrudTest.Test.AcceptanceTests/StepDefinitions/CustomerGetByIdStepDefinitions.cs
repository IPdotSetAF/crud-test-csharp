using System;
using TechTalk.SpecFlow;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerGetByIdStepDefinitions
    {
        [Given(@"the Id \((.*)\) of a customer")]
        public void GivenTheIdOfACustomer(int idSeed)
        {
            throw new PendingStepException();
        }

        [When(@"I request to get the customer by that Id")]
        public void WhenIRequestToGetTheCustomerByThatId()
        {
            throw new PendingStepException();
        }

        [Then(@"the action returns customer with Status code \((.*)\)")]
        public void ThenTheActionReturnsCustomerWithStatusCode(int statusCode)
        {
            throw new PendingStepException();
        }
    }
}
