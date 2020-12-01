using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<IEnumerable<Department>> GetDepartments();
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Appointment> AddAppointment(Appointment obj);
        Task<Appointment> GetAppointment(int id);
        Task<Appointment> UpdateAppointment(Appointment obj);
    }
}
