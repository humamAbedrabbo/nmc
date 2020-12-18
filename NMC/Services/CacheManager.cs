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
        private int life = 1;

        public CacheManager(MedContext context, IMemoryCache mem)
        {
            this.context = context;
            this.mem = mem;
        }

        public void Reset(string key)
        {
            mem.Remove(key);
        }

        public async Task<IEnumerable<Ward>> GetWards()
        {
            string key = nameof(Ward);
            List<Ward> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Wards
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<AdmissionType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.AdmissionTypes
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<DischargeType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.DischargeTypes
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<AppointmentType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.AppointmentTypes
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<RoomType> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.RoomTypes
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<RoomGrade> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.RoomGrades
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<Language> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Languages
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<Country> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Countries
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<City> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Cities
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
            List<Doctor> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Doctors
                    .Include(x => x.Ward)
                    .OrderBy(x => x.FirstName)
                    .AsNoTracking()
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
            List<Inpatient> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Inpatients
                    .Include(x => x.Patient).ThenInclude(x => x.Nationality)
                    .Include(x => x.Referrer)
                    .Include(x => x.Booking).ThenInclude(x => x.Allocations)
                    .Include(x => x.Ward)
                    .Include(x => x.Room).ThenInclude(x => x.RoomGrade)
                    .Include(x => x.RoomGrade)
                    .Include(x => x.AdmissionType)
                    .Include(x => x.DischargeType)
                    .Include(x => x.Statuses)
                    .Include(x => x.Bills)
                    .Where(x => x.Active)
                    .OrderBy(x => x.Patient.FirstName)
                    .AsNoTracking()
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
            List<Booking> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Bookings
                    .Include(x => x.Doctor)
                    .Include(x => x.Allocations)
                    .Where(x => x.Active)
                    .OrderBy(x => x.RequestDate)
                    .AsNoTracking()
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
            List<Room> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Rooms
                    .Include(x => x.RoomType)
                    .Include(x => x.RoomGrade)
                    .Include(x => x.Ward)
                    .OrderBy(x => x.Floor)
                    .AsNoTracking()
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
            List<Speciality> entry = null;

            if (!mem.TryGetValue(key, out entry))
            {
                // Key not in cache, so get data.
                entry = await context.Specialities
                    .OrderBy(x => x.SortKey)
                    .AsNoTracking()
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
