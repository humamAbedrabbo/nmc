using Microsoft.EntityFrameworkCore;
using System;
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

        public int Capacity { get; set; }

        public Unit Unit { get; set; }
    }
}
