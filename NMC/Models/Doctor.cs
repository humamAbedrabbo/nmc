using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name => $"{FirstName} {LastName}";

        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(75)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        [StringLength(75)]
        public string Speciality { get; set; }
        public string Biography { get; set; }

        [StringLength(30)] 
        public string Phone { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(200)] 
        public string Address { get; set; }


        [StringLength(200)] 
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
