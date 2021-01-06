using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Institution), IsUnique = false)]
    [Index(nameof(StartingYear), IsUnique = false)]
    [Index(nameof(CompletionYear), IsUnique = false)]
    public class DoctorEducation 
    {
        public int Id { get; set; }

        [Display(Name = "Doctor")] 
        public int DoctorId { get; set; }
        
        [Display(Name = "Doctor")] 
        public Doctor Doctor { get; set; }

        [Display(Name = "Institution"), Required, StringLength(100)] 
        public string Institution { get; set; }

        [Display(Name = "Subject"), StringLength(100)] 
        public string Subject { get; set; }

        [Display(Name = "Degree"), Required, StringLength(100)] 
        public string Degree { get; set; }

        [Display(Name = "Grade"), StringLength(50)] 
        public string Grade { get; set; }

        [Display(Name = "Starting Year")] 
        public int StartingYear { get; set; }

        [Display(Name = "Completion Year")] 
        public int CompletionYear { get; set; }
    }

}
