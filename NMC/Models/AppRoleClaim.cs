using Microsoft.AspNetCore.Identity;

namespace NMC.Models
{
    public class AppRoleClaim : IdentityRoleClaim<int>
    {
        public AppRole Role { get; set; }
    }
}

