using CrudTest.Bussiness.Contracts.DTOs.Customer;
using CrudTest.Bussiness.Domain.Entities;
using CrudTest.Bussiness.Domain.Entities.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace CrudTest.Test.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerObjectStepDefinitions
    {
        private Exception? exception;
        private CustomerGetDTO? tempCustomer;

        [Given(@"The customer data as \((.*),(.*),(.*),(.*),(.*),(.*)\)")]
        public void GivenTheCustomerDataAs(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, ulong bankAccountNumber)
        {
            tempCustomer = new CustomerGetDTO
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phoneNumber,
                BankAccountNumber = bankAccountNumber
            };
        }

        [When(@"Creating a Customer object")]
        public void WhenCreatingACustomerObject()
        {
            if (tempCustomer != null)
            {
                try
                {
                    var customer = new Customer
                    (
                        person: new Person(tempCustomer.FirstName, tempCustomer.LastName, DateOnly.FromDateTime(tempCustomer.DateOfBirth)),
                        email: new Email(tempCustomer.Email),
                        phoneNumber: new PhoneNumber(tempCustomer.PhoneNumber),
                        bankAccountNumber: new BankAccountNumber(tempCustomer.BankAccountNumber)
                    );
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }
        }

        [Then(@"We should have a \((.*)\) Customer")]
        public void ThenWeShouldHaveATrueCustomer(bool valid)
        {
            if (valid)
                Assert.Null(exception);
            else
                Assert.NotNull(exception);
        }
    }
}
