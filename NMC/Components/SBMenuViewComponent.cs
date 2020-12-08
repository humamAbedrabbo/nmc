using Microsoft.AspNetCore.Mvc;
using SBMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Components
{
    [ViewComponent(Name = "SBMenuView")]
    public class SBMenuViewComponent : ViewComponent
    {
        private readonly ISBMenu menu;

        public SBMenuViewComponent(ISBMenu menu)
        {
            this.menu = menu;
        }

        public async Task<IViewComponentResult> InvokeAsync(string roleName)
        {
            var results = await menu.GetSections(roleName);
            return View(results);
        }
    }
}
