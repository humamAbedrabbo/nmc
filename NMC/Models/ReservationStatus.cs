using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Owned]
    public class ReservationStatus
    {
        [Display(Name = "Status Time")]
        public DateTime StatusTime { get; set; }

        [Display(Name = "Status Type")]
        public ReservationStatusType StatusType { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Blocking Reservation")]
        public bool Block { get; set; }
    }
}
