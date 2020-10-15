using System;

namespace NMC.Models
{
    public class DoctorEducation
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Institution { get; set; }
        public string Subject { get; set; }
        public string Degree { get; set; }
        public string Grade { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}
