using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMC.Models
{
    [Index(nameof(FromDate), IsUnique = false)]
    [Index(nameof(ThruDate), IsUnique = false)]
    public class DoctorSchedule 
    {

        public DoctorSchedule()
        {
            FromDate = DateTime.Today;
        }

        public int Id { get; set; }

        [Display(Name = "Doctor")] 
        public int DoctorId { get; set; }

        [Display(Name = "Doctor")] 
        public Doctor Doctor { get; set; }

        [Display(Name = "From Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime FromDate { get; set; } = DateTime.Today;

        [Display(Name = "Thru Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime? ThruDate { get; set; }

        [Display(Name = "Available Days")] 
        public string Days { get; set; }
        
        [Display(Name = "Start Time"), Required, StringLength(20)] 
        public string StartTime { get; set; }
        
        [Display(Name = "End Time"), Required, StringLength(20)] 
        public string EndTime { get; set; }
        
        [Display(Name = "Message"), StringLength(150)] 
        public string Message { get; set; }

        [Display(Name = "Timing")] 
        public string Timing => $"{StartTime} - {EndTime}";

        [NotMapped]
        public string[] DaysList
        {
            get => Days?.Split(" ");
            set => Days = string.Join(" ", value);
        }
    }

}
