using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DepartmentDoctor> DepartmentDoctors { get; set; }
        public IEnumerable<DepartmentRoom> DepartmentRooms { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
