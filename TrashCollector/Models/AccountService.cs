using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class AccountService
    {
        [Key]
        public int Id { get; set; }
        public bool IsPickedUp { get; set; }
        public DateTime OneTimePickup { get; set; }
        public DateTime AccountStartDate { get; set; }
        public DateTime AccountEndDate { get; set; }
        public bool IsSuspended { get; set; }
        public DateTime StartDateSuspend { get; set; }
        public DateTime EndDateSuspend { get; set; }
    }
}
