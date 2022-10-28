using System;
using TechTalk.SpecFlow;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerUpdateStepDefinitions
    {
        [Given(@"the Id of an existing customer and data \((.*),(.*),(.*),(.*)\)")]
        public void GivenTheIdOfAnExistingCustomerAndData(int idSeed, string email, string phoneNumber, ulong bankAccountNumber)
        {
            throw new PendingStepException();
        }

        [When(@"updateing this customer using the data")]
        public void WhenUpdateingThisCustomerUsingTheData()
        {
            throw new PendingStepException();
        }

        [Then(@"the action should return \((.*)\)")]
        public void ThenTheActionShouldReturn(int statusCode)
        {
            throw new PendingStepException();
        }
    }
}
