using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class AppUser : IdentityUser
    {
        public int? DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
