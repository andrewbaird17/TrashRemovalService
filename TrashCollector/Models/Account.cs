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

        [Display(Name = "Pick Up Day")]
        public DayOfWeek PickUpDay { get; set; }
        public double Balance { get; set; }

        [Display(Name ="Picked Up")]
        public bool IsPickedUp { get; set; }

        [Display(Name = "Suspend Service")]
        public bool IsSuspended { get; set; }

        [Display(Name = "Start Date of Suspend Service")]
        public DateTime StartDateSuspend { get; set; }

        [Display(Name = "End Date of Suspend Service")]
        public DateTime EndDateSuspend { get; set; }

        [Display(Name = "One Time Pickup Date")]
        public DateTime OneTimePickup { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
