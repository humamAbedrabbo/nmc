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
using Microsoft.AspNetCore.Mvc.Rendering;
using NMC.Extensions;
using NMC.Domain.Models;
using NMC.Core.Services;
using NMC.Core;

namespace NMC.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ITypesRepository typesRepository;
        private readonly IWebHostEnvironment env;
        private readonly UserManager<AppUser> userManager;

        public AddEmployeeModel(IEmployeeRepository employeeRepository, 
            ITypesRepository typesRepository,
            IWebHostEnvironment env, 
            UserManager<AppUser> userManager)
        {
            this.employeeRepository = employeeRepository;
            this.typesRepository = typesRepository;
            this.env = env;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public Employee Employee { get; set; }

        public SelectList EmployeeTypesSelect { get; set; }
        public SelectList DepartmentsSelect { get; set; }

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

        public async Task OnGet()
        {
            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "NameAr" : "Name";
            EmployeeTypesSelect = new SelectList(await typesRepository.GetAllEmployeeTypes(), "Id", typeNameStr, Employee?.EmployeeTypeId);
            DepartmentsSelect = new SelectList(await employeeRepository.GetDepartments(), "Id", typeNameStr, Employee?.DepartmentId);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // Upload photo
                string photo = "user.jpg";
                if (Photo != null && Photo?.Length > 0)
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
                Employee.PhotoPath = photo;

                // Create user
                AppUser user = null;
                if (Employee.Username != null)
                {
                    user = await userManager.FindByNameAsync(Employee.Username);
                    if (user != null)
                    {
                        //TODO: Handle when doctor is employee
                        return RedirectToPage("/Error");
                    }

                    user = new AppUser { UserName = Employee.Username, Email = Employee.Email, PhoneNumber = Employee.Phone };
                    var createResult = await userManager.CreateAsync(user, Password);
                    if (!createResult.Succeeded)
                    {
                        return RedirectToPage("/Error");
                    }
                }

                Employee = await employeeRepository.AddEmployee(Employee);

                // Add Claims
                if (user != null)
                {
                    var addClaimResult = await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("EmployeeId", $"{Employee.Id}"));
                    if (!addClaimResult.Succeeded)
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
