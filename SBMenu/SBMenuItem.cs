using System;
using System.Collections.Generic;

namespace SBMenu
{
    public class SBMenuItem
    {
        public int Id { get; set; }
        public int SortKey { get; set; }
        public string Text { get; set; }
        public string HRef { get; set; }
        public string Icon { get; set; }
        public bool Visible { get; set; } = true;
        public bool Enabled { get; set; } = true;
        public int? ParentId { get; set; }
        public SBMenuItem Parent { get; set; }
        public List<SBMenuItem> Items { get; set; } = new();
        public List<SBMenuSectionItem> SectionItems { get; set; } = new();
    }
}
