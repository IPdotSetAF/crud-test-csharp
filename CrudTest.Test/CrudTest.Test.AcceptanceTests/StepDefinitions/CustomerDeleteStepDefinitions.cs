using System;
using TechTalk.SpecFlow;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerDeleteStepDefinitions
    {
        [Given(@"The Id \((.*)\) of a customer")]
        public void GivenTheIdOfACustomer(int idSeed)
        {
            throw new PendingStepException();
        }

        [When(@"sending delete request to action")]
        public void WhenSendingDeleteRequestToAction()
        {
            throw new PendingStepException();
        }

        [Then(@"the action should return Status code \((.*)\)")]
        public void ThenTheActionShouldReturnStatusCode(int statusCode)
        {
            throw new PendingStepException();
        }
    }
}
