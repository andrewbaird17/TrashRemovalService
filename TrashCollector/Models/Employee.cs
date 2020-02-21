﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Route Zip Code")]
        public int RouteZipCode { get; set; }

        [Display(Name = "Select Day to View Route List For")]
        public DayOfWeek SelectDayToView { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [NotMapped]
        public IEnumerable<Customer> Customers { get; set; }

    }
}
