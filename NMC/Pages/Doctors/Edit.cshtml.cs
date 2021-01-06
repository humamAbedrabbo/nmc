using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly NmcContext context;

        public EditModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Doctor Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Doctors";

        public MultiSelectList SpecSelect { get; set; }

        [BindProperty] 
        public List<int> Specs { get; set; } = new();

        public async Task InitDataAsync()
        {
            Specs = Entity?.Specialities.Select(x => x.Id).ToList();
            SpecSelect = new MultiSelectList(await context.Specialities.OrderBy(x => x.Name).ToListAsync(), "Id", "Name", Specs);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
                return Redirect("/NotFound");

            Entity = await context.Doctors
                .Include(x => x.Specialities)
                .Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (Entity == null)
                return Redirect("/NotFound");

            await InitDataAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<int> oldSpecs = Entity.Specialities.Select(x => x.Id).ToList();
                    var old = await context.Set<DoctorSpeciality>()
                        .Where(x => x.DoctorId == Entity.Id && oldSpecs.Contains(x.SpecialityId))
                        .ToListAsync();
                    context.Set<DoctorSpeciality>().RemoveRange(old);

                    await context.SaveChangesAsync();

                    Entity.Specialities = await context.Specialities
                    .Where(x => Specs.Contains(x.Id)).ToListAsync();

                    context.Set<Doctor>().Update(Entity);
                    await context.SaveChangesAsync();
                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }

            await InitDataAsync();
            return Page();
        }
    }
}
