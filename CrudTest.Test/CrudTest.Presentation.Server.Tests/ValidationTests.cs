using CrudTest.Bussiness.Domain.Entities;
using CrudTest.Bussiness.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Test.XUnitTests
{
    public class ValidationTests
    {
        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }

        [Theory]
        [InlineData("mahdi", "nazari", "2012-1-20", "989387016860", "test@test.com", 1212121212121212, true)]
        [InlineData("", "nazari", "2012-1-20", "989387016860", "test@test.com", 1212121212121212, false)]
        [InlineData("mahdi", "nazari", "2012-1-20", "989387016860", "test.com", 1212121212121212, false)]
        [InlineData("mahdi", "", "2012-1-20", "989387016860", "test@test.com", 1212121212121212, false)]
        [InlineData("mahdi", "nazari", "2012-1-20", "989387016860", "", 1212121212121212, false)]
        public void TestCustomerModelValidation(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, ulong bankAccNumber, bool isValid)
        {
            var customer = new Customer
            (
                person: new Person(firstName, lastName, DateOnly.FromDateTime(dateOfBirth)),
                phoneNumber: new PhoneNumber(phoneNumber),
                email: new Email(email),
                bankAccountNumber: new BankAccountNumber(bankAccNumber)
            );

            Assert.Equal(isValid, ValidateModel(customer));
        }
    }
}
