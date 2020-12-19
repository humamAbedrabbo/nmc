using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NMC.Models
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser<int>
    {
        public List<AppRole> Roles { get; set; } = new();
        public List<AppUserClaim> Claims { get; set; } = new();
        public List<AppUserToken> Tokens { get; set; } = new();
        public List<AppUserLogin> Logins { get; set; } = new();
    }
}
