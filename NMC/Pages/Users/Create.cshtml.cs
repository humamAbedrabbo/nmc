using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly NmcContext context;
        private readonly UserManager<AppUser> userManager;

        public CreateModel(NmcContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [BindProperty]
        public AppUser Entity { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? DoctorId { get; set; }

        [BindProperty]
        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Users";

        public string[] AppRoles => AppRole.GetRoles();

        public async Task OnGetAsync()
        {
            await GetDoctor();
        }

        public async Task GetDoctor()
        {
            if (DoctorId.HasValue)
            {
                var doc = await context.Doctors
                    .Where(x => x.Id == DoctorId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                ViewData["DoctorName"] = doc?.Name;
                Entity.PhoneNumber = doc?.Phone;
                Entity.Email = doc?.Email;
                if(!string.IsNullOrEmpty(doc?.Email))
                {
                    Entity.UserName = doc.Email.Split("@")[0];
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(string[] roles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Entity.Id = Guid.NewGuid().ToString("D");
                    if(DoctorId.HasValue)
                    {
                        var doctor = await context.Doctors.FindAsync(DoctorId);
                        if (doctor != null)
                        {
                            Entity.DoctorId = DoctorId;
                            doctor.UserId = Entity.Id;
                        }

                            
                    }
                    Entity.ConcurrencyStamp = Guid.NewGuid().ToString("D");
                    Entity.SecurityStamp = Guid.NewGuid().ToString("D");
                    Entity.NormalizedUserName = Entity.UserName.ToUpper();
                    Entity.NormalizedEmail = Entity.Email.ToUpper();
                    var hasher = new PasswordHasher<AppUser>();
                    Entity.PasswordHash = hasher.HashPassword(Entity, Password);
                    context.Set<AppUser>().Add(Entity);
                    await context.SaveChangesAsync();

                    if(roles != null)
                    {
                        await userManager.AddToRolesAsync(Entity, roles);
                    }

                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }

            await GetDoctor();
            return Page();
        }
    }
}
