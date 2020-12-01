using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<IEnumerable<Room>> GetRooms();
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<RoomGrade>> GetGrades();
        Task<Reservation> AddReservation(Reservation obj);
        Task<Reservation> GetReservation(int id);
        Task<Reservation> UpdateReservation(Reservation obj);
    }
}
