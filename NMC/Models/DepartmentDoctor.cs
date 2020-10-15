using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DepartmentDoctor
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
