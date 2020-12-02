using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Parties
{
    public class AddModel : PageModel
    {
        private readonly MedContext ctx;

        public AddModel(MedContext ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty(SupportsGet = true)]
        [TempData(Key = "RoleType")]
        [FromQuery]
        public string RoleType { get; set; }

        [BindProperty(SupportsGet = true)]
        [TempData(Key = "PartyType")]
        [FromQuery]
        public string PartyType { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PartyId { get; set; }

        [BindProperty]
        public Person Person { get; set; } = new();

        [BindProperty]
        public Organization Organization { get; set; } = new();

        [BindProperty]
        public PartyRole Item { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public void OnGet(string roleType, string partyType)
        {
            this.RoleType = (roleType ?? string.Empty).ToUpper();
            this.PartyType = (partyType ?? "O").ToUpper();

            ViewData["PageTitle"] = "Add " + ctx.RoleTypes.Find(this.RoleType)?.Name;

            if(PartyId > 0)
            {
                if(PartyType == "P")
                {
                    Person = ctx.People.Find(PartyId);
                }
                else
                {
                    Organization = ctx.Organizations.Find(PartyId);
                }
            }

            Item = new PartyRole { RoleTypeId = this.RoleType, From = DateTime.Now };

        }

        public IActionResult OnPost(string roleType, string partyType)
        {
            this.RoleType = (roleType ?? string.Empty).ToUpper();
            this.PartyType = (partyType ?? "O").ToUpper();


            if (ModelState.IsValid)
            {
                if (PartyType == "P")
                    Item.Party = Person;
                else
                    Item.Party = Organization;

                ctx.Add(Item);
                ctx.SaveChanges();

                return RedirectToPage("Index", new { roleType = RoleType, partyType = PartyType });
            }
            else
            {
                ViewData["PageTitle"] = "Add " + ctx.RoleTypes.Find(this.RoleType)?.Name;
                return Page();
            }
        }
    }
}
