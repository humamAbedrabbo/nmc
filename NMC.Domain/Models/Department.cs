using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Domain.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(75)]
        [Display(Name = "Department")]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Department (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Department Type")]
        public DepartmentType DepartmentType { get; set; }

        public ICollection<DepartmentDoctor> DepartmentDoctors { get; set; }
        public IEnumerable<DepartmentRoom> DepartmentRooms { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
