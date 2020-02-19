using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public double Balance { get; set; }
        public DayOfWeek PickUpDay { get; set; }

        [ForeignKey("AccountServices")]
        public int AccountServicesId { get; set; }
        public AccountService AccountServices { get; set; }
       
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
