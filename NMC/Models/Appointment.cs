using System;

namespace NMC.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppointmentTypeId { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Visitor { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Message { get; set; }
        public bool Active { get; set; }
    }
}
