using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
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
                    PhoneNumber = 989387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
                },
                new Customer
                {
                    Id = SeededGuid(3),
                    FirstName = "Saeed",
                    LastName = "Rezaii",
                    PhoneNumber = 19387016860,
                    BankAccountNumber = 1212121212121212,
                    Email = "ipdotsetaf.work@gmail.com",
                    DateOfBirth = DateTime.Now
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
            ); ;
        }

        private static Guid SeededGuid(int seed)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(seed).CopyTo(bytes, 0);
            return new Guid(MD5.HashData(bytes));
        }
    }
}
