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
        public static HtmlString YesNo(this IHtmlHelper htmlHelper, bool? yesNo)
        {
            var text = yesNo.HasValue ? (yesNo.Value ? "Yes" : "No") : string.Empty;
            return new HtmlString(text);
        }

        public static HtmlString DateTime(this IHtmlHelper htmlHelper, DateTime? value)
        {
            var text = value.HasValue ? (value.Value.ToString("dd-MM-yyyy hhtt")) : string.Empty;
            return new HtmlString(text);
        }

        public static HtmlString Date(this IHtmlHelper htmlHelper, DateTime? value)
        {
            var text = value.HasValue ? (value.Value.ToString("dd-MM-yyyy")) : string.Empty;
            return new HtmlString(text);
        }
    }
}
