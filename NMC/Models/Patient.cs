using System;
using System.Collections.Generic;

namespace NMC.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Married { get; set; }
        public int? Children { get; set; }
        public string NationalID { get; set; }
        public string PassportID { get; set; }
        public string ExternalID { get; set; }
        public string Comments { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Occupation { get; set; }
        public string WorkPhone { get; set; }

        public IEnumerable<Admission> Admissions { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
