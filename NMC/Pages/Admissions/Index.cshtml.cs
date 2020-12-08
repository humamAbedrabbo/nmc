using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Domain.Models;

using NMC.Core.Services;

namespace NMC.Pages.Admissions
{
    public class IndexModel : PageModel
    {
        private readonly IAdmissionRepository admRepository;

        public IndexModel(IAdmissionRepository admRepository)
        {
            this.admRepository = admRepository;
        }

        public IEnumerable<Admission> Admissions { get; private set; }

        public async Task OnGet()
        {
            Admissions = await admRepository.GetAllAdmissions();
        }
    }
}
