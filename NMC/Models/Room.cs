using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(RoomNo), IsUnique = true)]
    public class Room
    {
        [Key]
        [StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        public int Floor { get; set; }

        [Display(Name = "Ward")]
        public int? WardId { get; set; }

        [Display(Name = "Ward")]
        public Ward Ward { get; set; }

        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        [Display(Name = "Room Grade")]
        public int? RoomGradeId { get; set; }

        [Display(Name = "Room Grade")]
        public RoomGrade RoomGrade { get; set; }

        public string Name => $"{Floor}/{RoomNo}";

        public List<RoomAllocation> Allocations { get; set; } = new();
    }
}
