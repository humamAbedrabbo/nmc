using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class Unit
    {
        public int Id { get; set; }

        [Display(Name = "Unit Type")]
        public UnitType Type { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Unit Name (English)")]
        public string Name { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Unit Name (Arabic)")]
        public string NameAr { get; set; }

        public string this[string lang] => lang == "ar" ? NameAr : Name;

        public IEnumerable<Room> Rooms { get; set; }
    }
}
