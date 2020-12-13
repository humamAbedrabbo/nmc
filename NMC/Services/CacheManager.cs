using NMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NMC.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace NMC.Services
{
    public class CacheManager : ICacheManager
    {
        private readonly MedContext context;
        private readonly IMemoryCache cache;

        public CacheManager(MedContext context, IMemoryCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public async Task<IEnumerable<Ward>> GetWards()
        {
            IEnumerable<Ward> cacheEntry;
            string cacheKey = CacheKeys.Wards.ToString();

            // Look for cache key.
            if (!cache.TryGetValue(cacheKey, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = await context.Wards.AsNoTracking().ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));

                // Save data in cache.
                cache.Set(cacheKey, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public async Task<IEnumerable<RoomGrade>> GetRoomGrades()
        {
            IEnumerable<RoomGrade> cacheEntry;
            string cacheKey = CacheKeys.RoomGrades.ToString();

            // Look for cache key.
            if (!cache.TryGetValue(cacheKey, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = await context.RoomGrades.AsNoTracking().ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));

                // Save data in cache.
                cache.Set(cacheKey, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            IEnumerable<Room> cacheEntry;
            string cacheKey = CacheKeys.Rooms.ToString();

            // Look for cache key.
            if (!cache.TryGetValue(cacheKey, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = await context.Rooms
                    .Include(x => x.RoomGrade)
                    .Include(x => x.Ward)
                    .AsNoTracking().ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));

                // Save data in cache.
                cache.Set(cacheKey, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            IEnumerable<Doctor> cacheEntry;
            string cacheKey = CacheKeys.Doctors.ToString();

            // Look for cache key.
            if (!cache.TryGetValue(cacheKey, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = await context.Doctors
                    .AsNoTracking().ToListAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));

                // Save data in cache.
                cache.Set(cacheKey, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public void ResetCache(CacheKeys key)
        {
            cache.Remove(key.ToString());
        }
    }
}
