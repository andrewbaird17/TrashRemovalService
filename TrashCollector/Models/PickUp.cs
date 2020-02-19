using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class PickUp
    {
        [Key]
        public int Id { get; set; }
        public DateTime PickUpDate { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public bool IsPickedUp { get; set; }
    }
}
