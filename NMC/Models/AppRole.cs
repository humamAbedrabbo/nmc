using Microsoft.AspNetCore.Identity;
using static NMC.Constants;

namespace NMC.Models
{
    public class AppRole : IdentityRole
    {

        public static string[] GetRoles() => new[]
                {
                    RoleAdmin,
                    RoleIPDClerk,
                    RoleOPDClerk,
                    RoleRecieptionist,
                    RoleDoctor,
                    RoleNurse,
                    RoleFacilityAdmin,
                    RoleMedicalAdmin,
                    RoleBooking,
                    RoleTestLabAdmin,
                    RoleTestLabManager,
                    RoleTestLabClerk,
                    RoleTestLabTechnition,
                    RoleRadiologyLabAdmin,
                    RoleRadiologyLabClerk,
                    RoleRadiologyLabManager,
                    RoleRadiologyLabTechnition,
                    RoleAccountant,
                    RoleTopManagement
                };
    }
}
