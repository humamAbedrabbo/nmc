using System;
using System.Collections;
using System.Collections.Generic;

namespace NMC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string EmployeeNo { get; set; }
        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string PhotoPath { get; set; }
        public string Username { get; set; }
        public bool Active { get; set; }
        public IEnumerable<Attendance> AttendanceSheets { get; set; }
    }
}
