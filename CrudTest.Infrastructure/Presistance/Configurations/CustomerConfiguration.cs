using CrudTest.Bussiness.Contracts.Utils;
using CrudTest.Bussiness.Domain.Entities;
using CrudTest.Bussiness.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudTest.DataAccess.Presistance.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.OwnsOne(c => c.Person, op =>
            {
                op.Property(p => p.FirstName).IsRequired().HasColumnName(nameof(Person.FirstName));
                op.Property(p => p.LastName).IsRequired().HasColumnName(nameof(Person.LastName));
                op.Property(p => p.DateOfBirth).IsRequired().HasColumnName(nameof(Person.DateOfBirth));
                op.HasIndex(p => new { p.FirstName, p.LastName, p.DateOfBirth }).IsUnique(true);
            });

            builder.OwnsOne(c => c.Email, oe =>
            {
                oe.Property(e => e.Value).IsRequired().HasColumnName(nameof(Email));
                oe.HasIndex(e => e.Value).IsUnique(true);
            });

            builder.OwnsOne(c => c.PhoneNumber, op =>
            {
                op.Property(p => p.Value).IsRequired().HasColumnName(nameof(PhoneNumber));
            });

            builder.OwnsOne(c => c.BankAccountNumber, ob =>
            {
                ob.Property(b => b.Value).IsRequired().HasColumnName(nameof(BankAccountNumber));
            });
        }
    }
}
