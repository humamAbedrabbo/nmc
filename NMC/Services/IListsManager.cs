using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IListsManager
    {
        Task<SelectList> AdmissionTypeSelect(object key = null, string lang = "en");
        Task<SelectList> AppointmentTypeSelect(object key = null, string lang = "en");
        SelectList BloodTypeSelect(object key = null);
        Task<SelectList> BookingSelect(object key = null, string lang = "en");
        Task<SelectList> CitySelect(object key = null, string lang = "en");
        Task<SelectList> CountrySelect(object key = null, string lang = "en");
        Task<SelectList> DischargeTypeSelect(object key = null, string lang = "en");
        Task<SelectList> DoctorSelect(object key = null, string lang = "en");
        Task<SelectList> LanguageSelect(object key = null, string lang = "en");
        Task<SelectList> NationalitySelect(object key = null, string lang = "en");
        Task<SelectList> RoomGradeSelect(object key = null, string lang = "en");
        Task<SelectList> RoomSelect(object key = null, string lang = "en");
        Task<SelectList> RoomTypeSelect(object key = null, string lang = "en");
        Task<SelectList> SpecialitySelect(object key = null, string lang = "en");
        Task<SelectList> WardSelect(object key = null, string lang = "en");
    }
}