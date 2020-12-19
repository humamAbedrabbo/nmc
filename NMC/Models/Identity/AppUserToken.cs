using Microsoft.AspNetCore.Identity;

namespace NMC.Models
{
    public class AppUserToken : IdentityUserToken<int>
    {
        public AppUser User { get; set; }
    }
}

