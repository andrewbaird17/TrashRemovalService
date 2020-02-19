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
        public DayOfWeek PickUpDay { get; set; }
        public double Balance { get; set; }
        public bool IsPickedUp { get; set; }
        public bool IsSuspended { get; set; }
        public DateTime StartDateSuspend { get; set; }
        public DateTime EndDateSuspend { get; set; }
        public DateTime OneTimePickup { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
