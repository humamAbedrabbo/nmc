using System.Collections.Generic;

namespace NMC.Models
{
    public class AppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
