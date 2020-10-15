using System;
using System.Collections.Generic;

namespace NMC.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Speciality { get; set; }
        public string Biography { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime? JoiningDate { get; set; }
        public bool Consultant { get; set; }
        public bool Surgeon { get; set; }
        public bool Referrer { get; set; }
        public string PhotoPath { get; set; }
        public bool Active { get; set; }
        public IEnumerable<DepartmentDoctor> DepartmentDoctors { get; set; }
        public ICollection<DoctorEducation> EducationDetails { get; set; }
        public ICollection<DoctorExperience> ExperienceDetails { get; set; }
        public IEnumerable<DoctorSchedule> Schedules { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
