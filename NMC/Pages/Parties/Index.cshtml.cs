using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Parties
{
    public class IndexModel : PageModel
    {
        private readonly MedContext ctx;

        public IndexModel(MedContext ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty(SupportsGet = true)]
        [FromQuery]
        [TempData(Key = "RoleType")]
        public string RoleType { get; set; }

        [BindProperty(SupportsGet = true)]
        [FromQuery]
        [TempData(Key ="PartyType")]
        public string PartyType { get; set; }

        public IEnumerable<PartyRole> Items { get; set; }

        public void OnGet(string roleType, string partyType)
        {
            RoleType = (roleType ?? string.Empty).ToUpper();
            PartyType = (partyType ?? "O").ToUpper();

            Items = ctx.PartyRoles
                        .Include(p => p.Party)
                        .Where(p => p.RoleTypeId == RoleType && !p.Thru.HasValue)
                        .ToList();

            switch (RoleType)
            {
                case "DOCTOR":
                    ViewData["ActivePage"] = ActivePage.Doctors;
                    ViewData["PageTitle"] = "Doctors";
                    break;
                case "IN-PATIENT":
                    ViewData["ActivePage"] = ActivePage.InPatients;
                    ViewData["PageTitle"] = "In-Patients";
                    break;
                case "OUT_PATIENT":
                    ViewData["ActivePage"] = ActivePage.OutPatients;
                    ViewData["PageTitle"] = "Out-Patients";
                    break;
                case "DEPT":
                    ViewData["ActivePage"] = ActivePage.Departments;
                    ViewData["PageTitle"] = "Departments";
                    break;
                case "EMP":
                    ViewData["ActivePage"] = ActivePage.Employees;
                    ViewData["PageTitle"] = "Employees";
                    break;
            }
        }
    }
}
