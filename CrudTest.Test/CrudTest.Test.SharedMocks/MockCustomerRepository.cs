using Moq;
using CrudTest.Bussiness.Domain.RepositoryInterfaces;
using CrudTest.Bussiness.Domain.Entities;
using CrudTest.Bussiness.Contracts.Utils;
using CrudTest.Bussiness.Domain.Entities.ValueObjects;

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
                (
                    id : GuidUtil.SeededGuid(1),
                    person : new Person("Ali", "Nazari", new DateOnly(2012,1,20)),
                    phoneNumber : new PhoneNumber("989387016860"),
                    bankAccountNumber : new BankAccountNumber(1212121212121212),
                    email : new Email("ipdotsetaf.work@gmail.com")
                ),
                new Customer
                (
                    id : GuidUtil.SeededGuid(2),
                    person: new Person("Mahdi", "Nazari", new DateOnly(2012,1,20)),
                    phoneNumber: new PhoneNumber("982133341210"),
                    bankAccountNumber: new BankAccountNumber(1212121212121212),
                    email: new Email("ipdotsetaf.work@gmail.com")
                ),
                new Customer
                (
                    id : GuidUtil.SeededGuid(3),
                    person : new Person("Saeed", "Rezaii", new DateOnly(2012,1,20)),
                    phoneNumber : new PhoneNumber("16094032648"),
                    bankAccountNumber : new BankAccountNumber(1212121212121212),
                    email : new Email("ipdotsetaf.work@gmail.com")
                ),
                new Customer
                (
                    id : GuidUtil.SeededGuid(4),
                    person : new Person("Hooshang", "Motahari", new DateOnly(2012,1,20)),
                    phoneNumber : new PhoneNumber("989387016860"),
                    bankAccountNumber : new BankAccountNumber(1212121212121212),
                    email : new Email("ipdotsetaf.work@gmail.com")
                )
            };

            mock.Setup(m => m.GetAllAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => Customers);

            mock.Setup(m => m.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Guid id, bool trackChanges, CancellationToken cancellationToken) => Customers.FirstOrDefault(c => c.Id == id));

            mock.Setup(m => m.Insert(It.IsAny<Customer>()))
                .Callback((Customer customer) => Customers.Add(customer));

            mock.Setup(m => m.Remove(It.IsAny<Customer>()))
                .Callback((Customer customer) => Customers.Remove(customer));

            mock.Setup(m => m.EmailExists(It.IsAny<Email>()))
                .ReturnsAsync((Email email) => Customers.FirstOrDefault(c => c.Email.Value.Equals(email.Value)) != null);

            mock.Setup(m => m.CustomerExists(It.IsAny<Person>()))
                .ReturnsAsync((Person person) => Customers.FirstOrDefault(c => c.Person.FirstName.Equals(person.FirstName) &&
                                                                                c.Person.LastName.Equals(person.LastName) &&
                                                                                c.Person.DateOfBirth == person.DateOfBirth) != null);

            return mock;
        }
    }
}
