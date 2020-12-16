using Microsoft.CodeAnalysis.CSharp.Syntax;
using NMC.Models;
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
        public static int? GetUserDoctorId(this ClaimsPrincipal principal)
        {
            string claimValue = principal.FindFirstValue("DoctorId");
            if(!string.IsNullOrEmpty(claimValue) && int.TryParse(claimValue, out int doctorId))
            {
                return doctorId;
            }

            return null;
        }
    }
}
