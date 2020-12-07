using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee")]
        public Employee Employee { get; set; }

    }
}
