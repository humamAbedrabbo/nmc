using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class AppointmentType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Appointment Type")]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Appointment Type (ar)")]
        public string NameAr { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
