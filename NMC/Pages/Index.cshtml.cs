using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NMC.Models;

namespace NMC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public IndexModel(ILogger<IndexModel> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(string lang = null)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                if (User.HasClaim(x => x.Type == "Language"))
                {
                    var claim = User.FindFirst("Language");
                    await userManager.ReplaceClaimAsync(user, claim, new System.Security.Claims.Claim("Language", lang));
                }
                else
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("Language", lang));
                }
                var c = new CultureInfo(lang);
                c.DateTimeFormat = new DateTimeFormatInfo();
                c.DateTimeFormat.Calendar = new GregorianCalendar();
                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(c)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }

                );
                await signInManager.SignOutAsync();
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
