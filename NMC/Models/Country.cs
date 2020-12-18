using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    [Index(nameof(NationalityName), IsUnique = true)]
    [Index(nameof(NationalityNameAr), IsUnique = true)]
    public class Country
    {
        [Key]
        [StringLength(2)]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Country")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Country (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        [Display(Name = "Tel. Code")]
        public string TelecomCode { get; set; }

        [StringLength(2)]
        [Display(Name = "Language")]
        public string LanguageId { get; set; }

        [Display(Name = "Language")]
        public Language Language { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Nationality")]
        public string NationalityName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Nationality (ar)")]
        public string NationalityNameAr { get; set; }

        public List<City> Cities { get; set; } = new();
    }
}
