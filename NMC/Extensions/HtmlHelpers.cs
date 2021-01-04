using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Extensions
{
    public static class HtmlHelpers
    {
        public static HtmlString YesNo(this IHtmlHelper htmlHelper, bool yesNo)
        {
            var text = yesNo ? "Yes" : "No";
            return new HtmlString(text);
        }
    }
}
