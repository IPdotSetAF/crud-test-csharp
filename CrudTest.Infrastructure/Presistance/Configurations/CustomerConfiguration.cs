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
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.DateOfBirth).IsRequired();

            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique(true);

            builder.OwnsOne(c => c.Email, oe =>
            {
                oe.Property(e => e.Value).IsRequired().HasColumnName("Email");
                oe.HasIndex(e => e.Value).IsUnique(true);
            });

            builder.OwnsOne(c => c.PhoneNumber, op =>
            {
                op.Property(p => p.Value).IsRequired().HasColumnName("PhoneNumber");
            });

            builder.OwnsOne(c => c.BankAccountNumber, ob =>
            {
                ob.Property(b => b.Value).IsRequired().HasColumnName("BankAccountNumber");
            });


            builder.HasData(new Customer
            {
                Id = GuidUtil.SeededGuid(1),
                FirstName = "Ali",
                LastName = "Nazari",
                DateOfBirth = new DateOnly(2020, 11, 21)
            },
            new Customer
            {
                Id = GuidUtil.SeededGuid(2),
                FirstName = "Mahdi",
                LastName = "Nazari",
                DateOfBirth = new DateOnly(2020, 11, 21)
            },
            new Customer
            {
                Id = GuidUtil.SeededGuid(3),
                FirstName = "Saeed",
                LastName = "Rezaii",
                DateOfBirth = new DateOnly(2020, 11, 21)
            },
            new Customer
            {
                Id = GuidUtil.SeededGuid(4),
                FirstName = "Hooshang",
                LastName = "Motahari",
                DateOfBirth = new DateOnly(2020, 11, 21)
            });

            builder.OwnsOne(c => c.Email).HasData(
            new
            {
                CustomerId = GuidUtil.SeededGuid(1),
                Value = "ipdotsetaf.work@gmail.com"
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(2),
                Value = "ipdotsetaf@gmail.com"
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(3),
                Value = "testt@gmail.com"
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(4),
                Value = "test2@gmail.com"
            });

            builder.OwnsOne(c => c.PhoneNumber).HasData(
            new
            {
                CustomerId = GuidUtil.SeededGuid(1),
                Value = (ulong)989387016860
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(2),
                Value = (ulong)989387016860
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(3),
                Value = (ulong)19387016860
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(4),
                Value = (ulong)989387016860
            });

            builder.OwnsOne(c => c.BankAccountNumber).HasData(
            new
            {
                CustomerId = GuidUtil.SeededGuid(1),
                Value = (ulong)1212121212121212
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(2),
                Value = (ulong)1212121212121212
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(3),
                Value = (ulong)1212121212121212
            },
            new
            {
                CustomerId = GuidUtil.SeededGuid(4),
                Value = (ulong)1212121212121212
            });

        }
    }
}
