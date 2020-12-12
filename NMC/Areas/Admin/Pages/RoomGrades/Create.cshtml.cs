using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NMC.Data;
using NMC.Models;

namespace NMC.Areas.Admin.Pages.RoomGrades
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly MedContext context;

        public CreateModel(ILogger<CreateModel> logger, MedContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [BindProperty]
        public RoomGrade RoomGrade { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                context.RoomGrades.Add(RoomGrade);
                await context.SaveChangesAsync();
                
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
