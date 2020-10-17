using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        public string Name => $"{FirstName} {LastName}";

        [Required]
        [StringLength(75)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [StringLength(50)]
        [Display(Name = "Employee No.")]
        public string EmployeeNo { get; set; }

        [Display(Name = "Employee Type")]
        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? JoiningDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        [StringLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(30)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(200)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        public IEnumerable<Attendance> AttendanceSheets { get; set; }
    }
}
