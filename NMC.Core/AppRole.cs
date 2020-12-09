using Microsoft.AspNetCore.Identity;

namespace NMC.Core
{
    public class AppRole : IdentityRole<int>
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_ADMISSION = "Admission";
        public const string ROLE_DOCTOR = "Doctor";
    }
}
