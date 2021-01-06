using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Company), IsUnique = false)]
    [Index(nameof(Location), IsUnique = false)]
    [Index(nameof(FromYear), IsUnique = false)]
    [Index(nameof(ToYear), IsUnique = false)]
    public class DoctorExperience
    {
        public int Id { get; set; }

        [Display(Name = "Doctor")] 
        public int DoctorId { get; set; }
        
        [Display(Name = "Doctor")] 
        public Doctor Doctor { get; set; }
        
        [Display(Name = "Company"), Required, StringLength(100)] 
        public string Company { get; set; }
        
        [Display(Name = "Location"), StringLength(50)] 
        public string Location { get; set; }
        
        [Display(Name = "Position"), Required, StringLength(100)] 
        public string Position { get; set; }

        [Display(Name = "From Year")] 
        public int FromYear { get; set; }
        
        [Display(Name = "To Year")] 
        public int? ToYear { get; set; }
    }

}
