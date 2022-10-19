using Contracts;
using Entities.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                    Id = SeededGuid(1),
                    FirstName ="Ali",
                    LastName ="Nazari",
                    PhoneNumber = 989387016860,
                    BankAccountNumber=1212121212121212,
                    Email="ipdotsetaf.work@gmail.com",
                    DateOfBirth= DateTime.Now
                },
                new Customer
                {
                    Id = SeededGuid(2),
                    FirstName = "Mahdi",
                    LastName = "Nazari",
                    PhoneNumber = 982133341210,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
                },
                new Customer
                {
                    Id = SeededGuid(3),
                    FirstName = "Saeed",
                    LastName = "Rezaii",
                    PhoneNumber = 16094032648,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now.AddDays(-2)
                },
                new Customer
                {
                    Id = SeededGuid(4),
                    FirstName = "Hooshang",
                    LastName = "Motahari",
                    PhoneNumber = 989387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
                }
            };

            mock.Setup(m => m.GetAllCustomersAsync(It.IsAny<bool>()))
                .Returns(() => Customers);

            mock.Setup(m => m.GetCustomerAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns((Guid id) => Customers.FirstOrDefault(c => c.Id == id));

            mock.Setup(m => m.CreateCustomer(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.UpdateCustomer(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.DeleteCustomer(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.EmailExists(It.IsAny<string>()))
                .Returns((string email) => Customers.FirstOrDefault(c => c.Email.Equals(email)) != null);

            mock.Setup(m => m.CustomerExists(It.IsAny<Customer>()))
                .Returns((Customer customer) => Customers.FirstOrDefault(c => c.FirstName.Equals(customer.FirstName) &&
                                                                            c.LastName.Equals(customer.LastName) &&
                                                                            c.DateOfBirth == customer.DateOfBirth) != null);

            return mock;
        }

        private static Guid SeededGuid(int seed)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(seed).CopyTo(bytes, 0);
            return new Guid(MD5.HashData(bytes));
        }
    }
}
