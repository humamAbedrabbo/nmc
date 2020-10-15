﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string NameAr { get; set; }

        public ICollection<DepartmentDoctor> DepartmentDoctors { get; set; }
        public IEnumerable<DepartmentRoom> DepartmentRooms { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
