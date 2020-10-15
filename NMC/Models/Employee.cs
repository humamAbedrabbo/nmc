using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Employee
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

        [StringLength(50)]
        public string EmployeeNo { get; set; }
        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime? JoiningDate { get; set; }

        [StringLength(100)]
        public string PhotoPath { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(200)]
        public string Address { get; set; }


        [StringLength(200)]
        public string Email { get; set; }

        public string Username { get; set; }
        public bool Active { get; set; }
        public IEnumerable<Attendance> AttendanceSheets { get; set; }
    }
}
