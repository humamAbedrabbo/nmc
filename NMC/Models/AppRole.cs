using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class AppRole : IdentityRole<int>
    {
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

    }

}
