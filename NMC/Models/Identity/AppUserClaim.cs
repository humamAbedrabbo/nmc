using Microsoft.AspNetCore.Identity;

namespace NMC.Models
{
    public class AppUserClaim : IdentityUserClaim<int>
    {
        public AppUser User { get; set; }
    }
}

