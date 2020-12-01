using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NMC.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static bool IsCurrentUser(this ClaimsPrincipal principal, string id)
        {
            var currentUserId = GetUserId(principal);

            return string.Equals(currentUserId, id, StringComparison.OrdinalIgnoreCase);
        }

        public static string GetUserLanguage(this ClaimsPrincipal principal)
        {
            var lang = principal.FindFirstValue("Language");
            if (string.IsNullOrEmpty(lang))
                return "en";
            else
                return lang;

        }

        public static bool IsAdmin(this ClaimsPrincipal principal) => principal.IsInRole("Admin");
        public static bool IsDoctor(this ClaimsPrincipal principal) => principal.IsInRole("Doctor");
        public static bool IsFrontDesk(this ClaimsPrincipal principal) => principal.IsInRole("Front Desk");
        public static bool IsLabDoctor(this ClaimsPrincipal principal) => principal.IsInRole("Laboratory Doctor");
        public static bool IsLabTech(this ClaimsPrincipal principal) => principal.IsInRole("Laboratory Technician");
        public static bool IsAccountant(this ClaimsPrincipal principal) => principal.IsInRole("Accountant");
        public static bool IsManagement(this ClaimsPrincipal principal) => principal.IsInRole("Management");
    }
}
