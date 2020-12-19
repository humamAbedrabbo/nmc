using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Helpers
{
    /// <summary>
    /// Format a DateTime value with a given format pattern
    /// </summary>
    public class DateTagHelper : TagHelper
    {
        /// <summary>
        /// The Date to format
        /// </summary>
        public DateTime? Value { get; set; }

        /// <summary>
        /// The format pattern <code>"dd-MM-yyyy"</code>
        /// </summary>
        /// <example>dd-MM-yyyy</example>
        public string Format { get; set; } = "dd-MM-yyyy";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent(Value.HasValue ? Value.Value.ToString(Format) : "");
        }
    }
}
