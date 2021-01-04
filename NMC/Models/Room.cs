using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Floor), nameof(RoomNo), IsUnique = true)]
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Unit")]
        public int UnitId { get; set; }

        public int Floor { get; set; }

        [Required, StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room")]
        public string Name => $"{Floor}/{RoomNo}";

        public int Capacity { get; set; } = 1;

        [Display(Name = "Inpatient")]
        public int? CurrentInpatientId { get; set; }

        public Unit Unit { get; set; }
        public Inpatient CurrentInpatient { get; set; }

        public RoomStatus GetStatus()
        {
            if (CurrentInpatientId.HasValue) return RoomStatus.Reserved;

            return RoomStatus.Available;
        }

        public string GetStatusCss()
        {
            var status = GetStatus();
            switch(status)
            {
                case RoomStatus.Reserved:
                    return "status-red";
                default:
                    return "status-green";
            }
        }
    }
}
