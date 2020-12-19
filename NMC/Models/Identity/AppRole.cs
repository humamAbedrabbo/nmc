using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class AppRole : IdentityRole<int>
    {
        public List<AppUser> Users { get; set; } = new();
        public List<AppRoleClaim> Claims { get; set; } = new();
    }
}

