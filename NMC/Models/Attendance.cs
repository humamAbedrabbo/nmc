using System;

namespace NMC.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
