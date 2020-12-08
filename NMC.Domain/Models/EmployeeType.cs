using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public class EmployeeType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Employee Type")]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Employee Type (ar)")]
        public string NameAr { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
