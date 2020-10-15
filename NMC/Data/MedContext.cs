using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NMC.Models;

namespace NMC.Data
{
    public class MedContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public MedContext(DbContextOptions<MedContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<AppRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");

            builder.Entity<AppUser>()
                .HasAlternateKey(p => p.UserName)
                .HasName("AK_Username");
        }
    }
}
