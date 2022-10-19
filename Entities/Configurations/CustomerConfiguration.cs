using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedUtils;

namespace Entities.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
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
                    PhoneNumber = 989387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
                },
                new Customer
                {
                    Id = GuidUtils.SeededGuid(3),
                    FirstName = "Saeed",
                    LastName = "Rezaii",
                    PhoneNumber = 19387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
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
            ); ;
        }
    }
}
