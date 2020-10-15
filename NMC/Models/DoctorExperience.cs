using System;

namespace NMC.Models
{
    public class DoctorExperience
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
    }
}
