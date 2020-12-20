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
                    .OrderBy(x => x.Floor).ThenBy(x => x.Name)
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
                    .Include(x => x.Specialities)
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
                    .Include(x => x.Patient)
                    .Include(x => x.Referrer)
                    .Include(x => x.Booking).ThenInclude(x => x.Allocations)
                    .Include(x => x.Ward)
                    .Include(x => x.Room)
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
                    .Include(x => x.Allocations).ThenInclude(x => x.Room)
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
                    .Include(x => x.Ward)
                    .OrderBy(x => x.Floor).ThenBy(x => x.Code)
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
                    .OrderBy(x => x.Name)
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

        //public async Task<IEnumerable<AppUser>> GetUsers()
        //{
        //    string key = nameof(AppUser);
        //    List<AppUser> entry = null;

        //    if (!mem.TryGetValue(key, out entry))
        //    {
        //        // Key not in cache, so get data.
        //        entry = await context.Users
        //            .Include(x => x.Roles).ThenInclude(x => x.Claims)
        //            .Include(x => x.Claims)
        //            .Include(x => x.Doctor)
        //            .OrderBy(x => x.UserName)
        //            .ToListAsync();

        //        // Set cache options.
        //        var cacheEntryOptions = new MemoryCacheEntryOptions()
        //            // Keep in cache for this time, reset time if accessed.
        //            .SetSlidingExpiration(TimeSpan.FromSeconds(life));

        //        // Save data in cache.
        //        mem.Set(key, entry, cacheEntryOptions);
        //    }

        //    return entry;
        //}

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
