using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = false)]
    [Index(nameof(NameAr), IsUnique = false)]
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "City")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "City (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 1)]
        [Display(Name = "Country")]
        public string CountryId { get; set; }

        [Display(Name = "Country")]
        public Country Country { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        [Display(Name = "Tel. Code")]
        public string TelecomCode { get; set; }

    }
}
