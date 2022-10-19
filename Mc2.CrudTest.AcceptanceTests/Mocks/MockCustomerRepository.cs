using Contracts;
using Entities.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedUtils;

namespace Mc2.CrudTest.AcceptanceTests.Mocks
{
    internal class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetMock()
        {
            var mock = new Mock<ICustomerRepository>();

            var Customers = new List<Customer>()
            {
                new Customer
                {
                    Id = GuidUtils.SeededGuid(1),
                    FirstName ="Ali",
                    LastName ="Nazari",
                    PhoneNumber = 989387016860,
                    BankAccountNumber=1212121212121212,
                    Email="ipdotsetaf.work@gmail.com",
                    DateOfBirth= DateTime.Now
                },
                new Customer
                {
                    Id = GuidUtils.SeededGuid(2),
                    FirstName = "Mahdi",
                    LastName = "Nazari",
                    PhoneNumber = 982133341210,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
                },
                new Customer
                {
                    Id = GuidUtils.SeededGuid(3),
                    FirstName = "Saeed",
                    LastName = "Rezaii",
                    PhoneNumber = 16094032648,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now.AddDays(-2)
                },
                new Customer
                {
                    Id = GuidUtils.SeededGuid(4),
                    FirstName = "Hooshang",
                    LastName = "Motahari",
                    PhoneNumber = 989387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
                }
            };

            mock.Setup(m => m.GetAllCustomersAsync(It.IsAny<bool>()))
                .ReturnsAsync(() => Customers);

            mock.Setup(m => m.GetCustomerAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync((Guid id, bool trackChanges) => Customers.FirstOrDefault(c => c.Id == id));

            mock.Setup(m => m.CreateCustomer(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.UpdateCustomer(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.DeleteCustomer(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.EmailExists(It.IsAny<string>()))
                .ReturnsAsync((string email) => Customers.FirstOrDefault(c => c.Email.Equals(email)) != null);

            mock.Setup(m => m.CustomerExists(It.IsAny<Customer>()))
                .ReturnsAsync((Customer customer) => Customers.FirstOrDefault(c => c.FirstName.Equals(customer.FirstName) &&
                                                                            c.LastName.Equals(customer.LastName) &&
                                                                            c.DateOfBirth == customer.DateOfBirth) != null);

            return mock;
        }
    }
}
