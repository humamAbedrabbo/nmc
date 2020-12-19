using Microsoft.AspNetCore.Identity;

namespace NMC.Models
{
    public class AppUserLogin : IdentityUserLogin<int>
    {
        public AppUser User { get; set; }
    }
}

