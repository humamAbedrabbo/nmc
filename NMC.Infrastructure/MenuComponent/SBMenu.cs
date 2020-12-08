using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SBMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMC.Infrastructure.MenuComponent
{
    public class SBMenu : ISBMenu
    {
        private readonly MedContext context;
        private readonly IMemoryCache cache;

        public SBMenu(MedContext context, IMemoryCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public async Task<IEnumerable<SBMenuSection>> GetSections(string role)
        {
            IEnumerable<SBMenuSection> sections;
            string cacheKey = $"{role}:menu";

            if (!cache.TryGetValue(cacheKey, out sections))
            {
                // Key not in cache, so get data.
                sections = await context.SBMenuSections
                    .Include(x => x.SectionItems).ThenInclude(y => y.MenuItem).ThenInclude(x => x.Items)
                    .Where(x => x.Role == role)
                    .OrderBy(x => x.SortKey)
                    .ToListAsync();
                    

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                cache.Set(cacheKey, sections, cacheEntryOptions);
            }

            return sections;
        }
    }
}
