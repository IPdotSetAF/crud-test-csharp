using CrudTest.Core.Contracts.Utils;
using CrudTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudTest.Infrastructure.Presistance.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(c => c.Id);
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(c => c.Email).IsRequired();

            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique(true);
            builder.HasIndex(c => c.Email).IsUnique(true);

            builder.HasData(GetSeedData());
        }

        private Customer[] GetSeedData()
        {
            return new[]
            {
                new Customer
                {
                    Id = GuidUtil.SeededGuid(1),
                    FirstName ="Ali",
                    LastName ="Nazari",
                    PhoneNumber = 989387016860,
                    BankAccountNumber=1212121212121212,
                    Email="ipdotsetaf.work@gmail.com",
                    DateOfBirth= new DateOnly(2020,11,21)
                },
                new Customer
                {
                    Id = GuidUtil.SeededGuid(2),
                    FirstName = "Mahdi",
                    LastName = "Nazari",
                    PhoneNumber = 989387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf@gmail.com",
                    DateOfBirth = new DateOnly(2020, 11, 21)
                },
                new Customer
                {
                    Id = GuidUtil.SeededGuid(3),
                    FirstName = "Saeed",
                    LastName = "Rezaii",
                    PhoneNumber = 19387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "testt@gmail.com",
                    DateOfBirth = new DateOnly(2020, 11, 21)
                },
                new Customer
                {
                    Id = GuidUtil.SeededGuid(4),
                    FirstName = "Hooshang",
                    LastName = "Motahari",
                    PhoneNumber = 989387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "test2@gmail.com",
                    DateOfBirth = new DateOnly(2020, 11, 21)
                }
            };
        }
    }
}
