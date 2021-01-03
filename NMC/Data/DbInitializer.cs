using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NMC.Models;

namespace NMC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NmcContext context)
        {
            if(!context.Users.Any())
            {
                var admin = new AppUser
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@nmc",
                    NormalizedEmail = "ADMIN@NMC",
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                };
                var hasher = new PasswordHasher<AppUser>();
                admin.PasswordHash = hasher.HashPassword(admin, "123456");
                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
