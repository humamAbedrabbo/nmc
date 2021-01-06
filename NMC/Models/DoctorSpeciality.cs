using System.ComponentModel.DataAnnotations.Schema;

namespace NMC.Models
{
    [Table("DoctorSpecialities")]
    public class DoctorSpeciality
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }

}
