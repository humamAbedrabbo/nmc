using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMenu
{
    public interface ISBMenu
    {
        Task<IEnumerable<SBMenuSection>> GetSections(string role);
    }
}
