using System.Collections.Generic;

namespace NMC.Models
{
    public class EmployeeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
