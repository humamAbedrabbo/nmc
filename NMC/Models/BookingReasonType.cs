using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class BookingReasonType
    {
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Reason Type (English)")]
        public string Name { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Reason Type (Arabic)")]
        public string NameAr { get; set; }

        public string this[string lang] => lang == "ar" ? NameAr : Name;
    }
}
