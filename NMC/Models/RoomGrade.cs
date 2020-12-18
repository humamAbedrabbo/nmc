using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class RoomGrade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Room Grade")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Room Grade (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        public int Level { get; set; }

        public int Capacity { get; set; }
    }
}
