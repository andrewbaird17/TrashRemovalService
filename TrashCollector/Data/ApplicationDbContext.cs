﻿using System;
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
        public DbSet<AccountService> AccountServices { get; set; }
        public DbSet<PickUp> PickUps { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE"
                    }, new IdentityRole
                    {
                        Name = "Customer",
                        NormalizedName = "CUSTOMER"
                    }
                );
        }
    }
}
