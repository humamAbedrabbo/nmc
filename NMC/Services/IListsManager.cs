using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IListsManager
    {
        Task<SelectList> AdmissionTypeSelect(string key = null, string lang = "en");
        Task<SelectList> AppointmentTypeSelect(string key = null, string lang = "en");
        SelectList BloodTypeSelect(string key = null);
        Task<SelectList> CitySelect(string key = null, string lang = "en");
        Task<SelectList> CountrySelect(string key = null, string lang = "en");
        Task<SelectList> DischargeTypeSelect(string key = null, string lang = "en");
        Task<SelectList> DoctorSelect(string key = null, string lang = "en");
        Task<SelectList> LanguageSelect(string key = null, string lang = "en");
        Task<SelectList> NationalitySelect(string key = null, string lang = "en");
        Task<SelectList> RoomGradeSelect(string key = null, string lang = "en");
        Task<SelectList> RoomSelect(string key = null, string lang = "en");
        Task<SelectList> RoomTypeSelect(string key = null, string lang = "en");
        Task<SelectList> SpecialitySelect(string key = null, string lang = "en");
        Task<SelectList> WardSelect(string key = null, string lang = "en");
    }
}