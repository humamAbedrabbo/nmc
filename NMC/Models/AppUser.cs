﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NMC.Models
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser<int>
    {
    }

    public class AppRole : IdentityRole<int>
    {

    }
}
