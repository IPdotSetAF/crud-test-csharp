using System;
using TechTalk.SpecFlow;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerGetAllStepDefinitions
    {
        [When(@"I request to get all customers")]
        public void WhenIRequestToGetAllCustomers()
        {
            throw new PendingStepException();
        }

        [Then(@"the action should return a list of all customers with Status code (.*)")]
        public void ThenTheActionShouldReturnAListOfAllCustomersWithStatusCode(int statusCode)
        {
            throw new PendingStepException();
        }
    }
}
