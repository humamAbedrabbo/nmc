using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NMC.Data;
using NMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Services
{
    public class CacheManager : ICacheManager
    {
        private readonly MedContext context;
        private readonly IMemoryCache mem;

        public CacheManager(MedContext context, IMemoryCache mem)
        {
            this.context = context;
            this.mem = mem;
        }

        public async Task<IEnumerable<Ward>> GetWards()
        {
            string key = nameof(Ward);
            int life = 20;
            List<Ward> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Wards
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<AdmissionType>> GetAdmissionTypes()
        {
            string key = nameof(AdmissionType);
            int life = 20;
            List<AdmissionType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.AdmissionTypes
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<DischargeType>> GetDischargeTypes()
        {
            string key = nameof(DischargeType);
            int life = 20;
            List<DischargeType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.DischargeTypes
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<AppointmentType>> GetAppointmentTypes()
        {
            string key = nameof(AppointmentType);
            int life = 20;
            List<AppointmentType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.AppointmentTypes
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<RoomType>> GetRoomTypes()
        {
            string key = nameof(RoomType);
            int life = 20;
            List<RoomType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.RoomTypes
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<RoomGrade>> GetRoomGrades()
        {
            string key = nameof(RoomGrade);
            int life = 20;
            List<RoomGrade> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.RoomGrades
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<Language>> GetLanguages()
        {
            string key = nameof(Language);
            int life = 20;
            List<Language> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Languages
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            string key = nameof(Country);
            int life = 20;
            List<Country> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Countries
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            string key = nameof(City);
            int life = 20;
            List<City> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Cities
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            string key = nameof(Doctor);
            int life = 20;
            List<Doctor> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Doctors
                    .Include(x => x.Ward)
                    .OrderBy(x => x.FirstName)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<Inpatient>> GetInpatients()
        {
            string key = nameof(Inpatient);
            int life = 20;
            List<Inpatient> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Inpatients
                    .Include(x => x.Patient).ThenInclude(x => x.Nationality)
                    .Include(x => x.Referrer)
                    .Include(x => x.Booking)
                    .Include(x => x.Ward)
                    .Include(x => x.Room).ThenInclude(x => x.RoomGrade)
                    .Include(x => x.RoomGrade)
                    .Include(x => x.AdmissionType)
                    .Include(x => x.DischargeType)
                    .Include(x => x.Statuses)
                    .Include(x => x.Bills)
                    .Where(x => x.Active)
                    .OrderBy(x => x.Patient.FirstName)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            string key = nameof(Booking);
            int life = 20;
            List<Booking> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Bookings
                    .Include(x => x.Doctor)
                    .Include(x => x.Allocations)
                    .Where(x => x.Active)
                    .OrderBy(x => x.RequestDate)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            string key = nameof(Room);
            int life = 20;
            List<Room> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Rooms
                    .Include(x => x.RoomType)
                    .Include(x => x.RoomGrade)
                    .Include(x => x.Ward)
                    .OrderBy(x => x.Floor)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<Speciality>> GetSpecialities()
        {
            string key = nameof(Speciality);
            int life = 20;
            List<Speciality> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Specialities
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            string key = nameof(AppUser);
            int life = 20;
            List<AppUser> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Users
                    .Include(x => x.Roles).ThenInclude(x => x.Claims)
                    .Include(x => x.Claims)
                    .Include(x => x.Doctor)
                    .OrderBy(x => x.UserName)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }
        
        public async Task<IEnumerable<AppRole>> GetRoles()
        {
            string key = nameof(AppRole);
            int life = 20;
            List<AppRole> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Roles
                    .Include(x => x.Users).ThenInclude(x => x.Claims)
                    .Include(x => x.Claims)
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(life));

                // Save data in cache.
                mem.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

    }
}
