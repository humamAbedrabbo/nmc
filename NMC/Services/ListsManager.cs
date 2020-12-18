using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Services
{
    public class ListsManager : IListsManager
    {
        private readonly ICacheManager mem;

        public ListsManager(ICacheManager mem)
        {
            this.mem = mem;
        }

        public SelectList BloodTypeSelect(object key = null)
        {
            var items = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };

            return new SelectList(items.Select(x => new SelectListItem { Value = x, Text = x }), key);
        }

        public async Task<SelectList> LanguageSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetLanguages();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }
        
        public async Task<SelectList> BookingSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetBookings();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", "Name", key);
        }

        public async Task<SelectList> CountrySelect(object key = null, string lang = "en")
        {
            var items = await mem.GetCountries();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> NationalitySelect(object key = null, string lang = "en")
        {
            var items = await mem.GetCountries();
            bool isArabic = ("ar" == lang?.ToLower());
            // return new SelectList(items.Select(x => new SelectListItem { Value = x.Id, Text = (isArabic ? x.NationalityNameAr : x.NationalityName) }), key);
            return new SelectList(items, "Id", (isArabic ? "NationalityNameAr" : "NationalityName"), key);
        }

        public async Task<SelectList> CitySelect(object key = null, string lang = "en")
        {
            var items = await mem.GetCities();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> WardSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetWards();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> RoomTypeSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetRoomTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> RoomGradeSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetRoomGrades();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> RoomSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetRooms();
            bool isArabic = ("ar" == lang?.ToLower());

            return new SelectList(items, "RoomNo", "Name", key);
        }

        public async Task<SelectList> AdmissionTypeSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetAdmissionTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            //return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> DischargeTypeSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetDischargeTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> SpecialitySelect(object key = null, string lang = "en")
        {
            var items = await mem.GetSpecialities();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> AppointmentTypeSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetAppointmentTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }

        public async Task<SelectList> DoctorSelect(object key = null, string lang = "en")
        {
            var items = await mem.GetDoctors();
            bool isArabic = ("ar" == lang?.ToLower());

            return new SelectList(items, "Id", (isArabic ? "NameAr" : "Name"), key);
        }


    }
}
