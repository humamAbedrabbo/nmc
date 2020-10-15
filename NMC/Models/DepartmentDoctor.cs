namespace NMC.Models
{
    public class DepartmentDoctor
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
