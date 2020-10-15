using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name => $"{FirstName} {LastName}";

        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(75)]
        public string LastName { get; set; }

        [StringLength(75)]
        public string FatherName { get; set; }

        [StringLength(75)]
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Married { get; set; }
        public int? Children { get; set; }

        [StringLength(50)]
        public string NationalID { get; set; }

        [StringLength(50)]
        public string PassportID { get; set; }

        [StringLength(50)]
        public string ExternalID { get; set; }

        public string Comments { get; set; }

        [StringLength(75)]
        public string Nationality { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(200)]
        public string Address { get; set; }


        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(75)]
        public string Occupation { get; set; }

        [StringLength(30)]
        public string WorkPhone { get; set; }

        public IEnumerable<Admission> Admissions { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
