using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;
using NMC.Core;

namespace NMCUI.Areas.UI1.Pages.Doctors
{
    public class AddDoctorModel : PageModel
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IWebHostEnvironment env;
        private readonly UserManager<AppUser> userManager;

        public AddDoctorModel(IDoctorRepository doctorRepository, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            this.doctorRepository = doctorRepository;
            this.env = env;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public Doctor Doctor { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        [Display(Name = "Photo")]
        public IFormFile Photo { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // Upload photo
                string photo = "user.jpg";
                if(Photo != null && Photo?.Length > 0)
                {
                    string uploadsFolder = Path.Combine(env.WebRootPath, "images");
                    Directory.CreateDirectory(uploadsFolder);
                    photo = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, photo);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Photo.CopyTo(fileStream);
                    }
                }
                Doctor.PhotoPath = photo;

                // Create user
                AppUser user = null;
                if (Doctor.Username != null)
                {
                    user = await userManager.FindByNameAsync(Doctor.Username);
                    if (user != null)
                    {
                        //TODO: Handle when doctor is employee
                        return RedirectToPage("/Error");
                    }

                    user = new AppUser { UserName = Doctor.Username, Email = Doctor.Email, PhoneNumber = Doctor.Phone };
                    var createResult = await userManager.CreateAsync(user, Password);
                    if (!createResult.Succeeded)
                    {
                        return RedirectToPage("/Error");
                    }
                }

                Doctor = await doctorRepository.AddDoctor(Doctor);
                
                // Add Claims
                if(user != null)
                {
                    var addClaimResult = await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("DoctorId", $"{Doctor.Id}"));
                    if(!addClaimResult.Succeeded)
                    {
                        return RedirectToPage("/Error");
                    }
                }


                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
