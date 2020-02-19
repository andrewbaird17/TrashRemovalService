using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Models;

namespace TrashCollector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE"
                    },
                    new IdentityRole
                    {
                        Name = "Customer",
                        NormalizedName = "CUSTOMER"
                    }
                );
            //base.OnModelCreating(builder);
            //builder.Entity<Employee>()
            //    .HasData(
            //        new Employee
            //        {
            //            Id = 1,
            //            Name = "Steve",
            //            RouteZipCode = 53217
            //        },
            //        new Employee
            //        {
            //            Id = 2,
            //            Name = "Alex",
            //            RouteZipCode = 53151
            //        }
            //    );
            //base.OnModelCreating(builder);
            //builder.Entity<Address>()
            //    .HasData(
            //        new Address
            //        {
            //            Id = 1,
            //            StreetAddress = "12821 W Ohio Dr",
            //            City = "New Berlin",
            //            State = "Wisconsin",
            //            ZipCode = 53151
            //        },
            //        new Address
            //        {
            //            Id = 2,
            //            StreetAddress = "15636 W El Dorado Dr",
            //            City = "New Berlin",
            //            State = "Wisconsin",
            //            ZipCode = 53151
            //        },
            //        new Address
            //        {
            //            Id = 3,
            //            StreetAddress = "5723 N Santa Monica Blvd",
            //            City = "Whitefish Bay",
            //            State = "Wisconsin",
            //            ZipCode = 53217
            //        },
            //        new Address
            //        {
            //            Id = 4,
            //            StreetAddress = "1020 E Quarles Pl",
            //            City = "Fox Point",
            //            State = "Wisconsin",
            //            ZipCode = 53217
            //        },
            //        new Address
            //        {
            //            Id = 5,
            //            StreetAddress = "8112 N Poplar Dr",
            //            City = "Fox Point",
            //            State = "Wisconsin",
            //            ZipCode = 53217
            //        },
            //        new Address
            //        {
            //            Id = 6,
            //            StreetAddress = "13295 W Old Oak Ln",
            //            City = "New Berlin",
            //            State = "Wisconsin",
            //            ZipCode = 53151
            //        }
            //    );
        }
    }
}
