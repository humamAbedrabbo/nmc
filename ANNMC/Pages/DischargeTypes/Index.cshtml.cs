using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Models;

using NMC.Services;

namespace NMC.Pages.DischargeTypes
{
    public class IndexModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public IndexModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        public IEnumerable<DischargeType> DischargeTypes { get; private set; }

        public async Task OnGet()
        {
            DischargeTypes = await typesRepository.GetAllDischargeTypes();
        }
    }
}