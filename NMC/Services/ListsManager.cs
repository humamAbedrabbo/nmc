﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        public SelectList BloodTypeSelect(string key = null)
        {
            var items = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };

            return new SelectList(items.Select(x => new SelectListItem { Value = x, Text = x }), key);
        }

        public async Task<SelectList> LanguageSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetLanguages();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id, Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> CountrySelect(string key = null, string lang = "en")
        {
            var items = await mem.GetCountries();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id, Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> NationalitySelect(string key = null, string lang = "en")
        {
            var items = await mem.GetCountries();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id, Text = (isArabic ? x.NationalityNameAr : x.NationalityName) }), key);
        }

        public async Task<SelectList> CitySelect(string key = null, string lang = "en")
        {
            var items = await mem.GetCities();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> WardSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetWards();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> RoomTypeSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetRoomTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> RoomGradeSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetRoomGrades();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> RoomSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetRooms();
            bool isArabic = ("ar" == lang?.ToLower());

            return new SelectList(items.Select(x => new SelectListItem { Value = x.RoomNo, Text = x.Name }), key);
        }

        public async Task<SelectList> AdmissionTypeSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetAdmissionTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> DischargeTypeSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetDischargeTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> SpecialitySelect(string key = null, string lang = "en")
        {
            var items = await mem.GetSpecialities();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> AppointmentTypeSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetAppointmentTypes();
            bool isArabic = ("ar" == lang?.ToLower());
            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (isArabic ? x.NameAr : x.Name) }), key);
        }

        public async Task<SelectList> DoctorSelect(string key = null, string lang = "en")
        {
            var items = await mem.GetDoctors();
            bool isArabic = ("ar" == lang?.ToLower());

            return new SelectList(items.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }), key);
        }


    }
}