using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface ITypesRepository
    {
        Task<IEnumerable<AdmissionType>> GetAllAdmissionTypes();
        Task<IEnumerable<AppointmentType>> GetAllAppointmentTypes();
        Task<IEnumerable<DischargeType>> GetAllDischargeTypes();
        Task<IEnumerable<EmployeeType>> GetAllEmployeeTypes();
        Task<IEnumerable<RoomType>> GetAllRoomTypes();
        Task<IEnumerable<RoomGrade>> GetAllRoomGrades();
        Task<AdmissionType> AddAdmissionType(AdmissionType obj);
        Task<AppointmentType> AddAppointmentType(AppointmentType obj);
        Task<DischargeType> AddDischargeType(DischargeType obj);
        Task<EmployeeType> AddEmployeeType(EmployeeType obj);
        Task<RoomType> AddRoomType(RoomType obj);
        Task<RoomGrade> AddRoomGrade(RoomGrade obj);
        Task<AdmissionType> GetAdmissionType(int id);
        Task<AppointmentType> GetAppointmentType(int id);
        Task<DischargeType> GetDischargeType(int id);
        Task<EmployeeType> GetEmployeeType(int id);
        Task<RoomGrade> GetRoomGrade(int id);
        Task<RoomType> GetRoomType(int id);
        Task<AdmissionType> UpdateAdmissionType(AdmissionType obj);
        Task<AppointmentType> UpdateAppointmentType(AppointmentType obj);
        Task<DischargeType> UpdateDischargeType(DischargeType obj);
        Task<EmployeeType> UpdateEmployeeType(EmployeeType obj);
        Task<RoomGrade> UpdateRoomGrade(RoomGrade obj);
        Task<RoomType> UpdateRoomType(RoomType obj);
    }
}
