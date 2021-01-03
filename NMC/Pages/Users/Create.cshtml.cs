using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly NmcContext context;

        public CreateModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public AppUser Entity { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Entity.ConcurrencyStamp = Guid.NewGuid().ToString("D");
                    Entity.SecurityStamp = Guid.NewGuid().ToString("D");
                    Entity.NormalizedUserName = Entity.UserName.ToUpper();
                    Entity.NormalizedEmail = Entity.Email.ToUpper();
                    var hasher = new PasswordHasher<AppUser>();
                    Entity.PasswordHash = hasher.HashPassword(Entity, Password);
                    context.Set<AppUser>().Add(Entity);
                    await context.SaveChangesAsync();
                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            return Page();
        }
    }
}
