using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Owned]
    public class ReservationStatus
    {
        public DateTime StatusTime { get; set; }
        public ReservationStatusType StatusType { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
        public bool Block { get; set; }
    }
}
