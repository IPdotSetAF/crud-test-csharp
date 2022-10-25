using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
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
        [InlineData("mahdi", "nazari", "2012-1-20", 989387016860, "test@test.com", 1212121212121212, true)]
        [InlineData(null, "nazari", "2012-1-20", 989387016860, "test@test.com", 1212121212121212, false)]
        [InlineData("mahdi", "nazari", "2012-1-20", 989387016860, "test.com", 1212121212121212, false)]
        [InlineData("mahdi", "", "2012-1-20", 989387016860, "test@test.com", 1212121212121212, false)]
        [InlineData("mahdi", "nazari", "2012-1-20", 989387016860, "", 1212121212121212, false)]
        public void TestCustomerModelValidation(string? firstName, string? lastName, DateTime dateOfBirth, ulong phoneNumber, string? email, ulong bankAccNumber, bool isValid)
        {
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateOnly.FromDateTime(dateOfBirth),
                PhoneNumber = phoneNumber,
                Email = email,
                BankAccountNumber = bankAccNumber
            };

            Assert.Equal(isValid, ValidateModel(customer));
        }
    }
}
