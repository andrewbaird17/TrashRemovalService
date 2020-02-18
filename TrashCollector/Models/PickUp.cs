﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class PickUp
    {
        [Key]
        public int Id { get; set; }

        public DayOfWeek PickUpDay { get; set; }
        public DateTime OneTimePickup { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsPickedUp { get; set; }
        public DateTime StartDateSuspend { get; set; }
        public DateTime EndDateSuspend { get; set; }
    }
}