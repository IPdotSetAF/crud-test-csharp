using Moq;
using CrudTest.Core.Domain.RepositoryInterfaces;
using CrudTest.Core.Domain.Entities;
using CrudTest.Core.Contracts.Utils;
using CrudTest.Core.Domain.Entities.ValueObjects;

namespace CrudTest.Test.SharedMocks
{
    public class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetMock()
        {
            var mock = new Mock<ICustomerRepository>();

            var Customers = new List<Customer>()
            {
                new Customer
                {
                    Id = GuidUtil.SeededGuid(1),
                    FirstName = "Ali",
                    LastName = "Nazari",
                    PhoneNumber =  new PhoneNumber("989387016860"),
                    BankAccountNumber = new BankAccountNumber(1212121212121212),
                    Email = new Email("ipdotsetaf.work@gmail.com"),
                    DateOfBirth= new DateOnly(2012,1,20)
                },
                new Customer
                {
                    Id = GuidUtil.SeededGuid(2),
                    FirstName = "Mahdi",
                    LastName = "Nazari",
                    PhoneNumber =  new PhoneNumber("982133341210"),
                    BankAccountNumber = new BankAccountNumber(1212121212121212),
                    Email = new Email("ipdotsetaf.work@gmail.com"),
                    DateOfBirth= new DateOnly(2012,1,20)
                },
                new Customer
                {
                    Id = GuidUtil.SeededGuid(3),
                    FirstName = "Saeed",
                    LastName = "Rezaii",
                    PhoneNumber =  new PhoneNumber("16094032648"),
                    BankAccountNumber = new BankAccountNumber(1212121212121212),
                    Email = new Email("ipdotsetaf.work@gmail.com"),
                    DateOfBirth= new DateOnly(2012,1,20)
                },
                new Customer
                {
                    Id = GuidUtil.SeededGuid(4),
                    FirstName = "Hooshang",
                    LastName = "Motahari",
                    PhoneNumber =  new PhoneNumber("989387016860"),
                    BankAccountNumber = new BankAccountNumber(1212121212121212),
                    Email = new Email("ipdotsetaf.work@gmail.com"),
                    DateOfBirth= new DateOnly(2012,1,20)
                }
            };

            mock.Setup(m => m.GetAllAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => Customers);

            mock.Setup(m => m.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Guid id, bool trackChanges, CancellationToken cancellationToken) => Customers.FirstOrDefault(c => c.Id == id));

            mock.Setup(m => m.Insert(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.Remove(It.IsAny<Customer>()))
                .Callback(() => { return; });

            mock.Setup(m => m.EmailExists(It.IsAny<Email>()))
               .ReturnsAsync((Email email) => Customers.FirstOrDefault(c => c.Email.Equals(email)) != null);

            mock.Setup(m => m.CustomerExists(It.IsAny<Customer>()))
                .ReturnsAsync((Customer customer) => Customers.FirstOrDefault(c => c.FirstName.Equals(customer.FirstName) &&
                                                                            c.LastName.Equals(customer.LastName) &&
                                                                            c.DateOfBirth == customer.DateOfBirth) != null);

            return mock;
        }
    }
}
