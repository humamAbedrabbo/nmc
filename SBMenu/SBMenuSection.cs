using System.Collections.Generic;

namespace SBMenu
{
    public class SBMenuSection
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public int SortKey { get; set; }
        public string Text { get; set; }
        public List<SBMenuSectionItem> SectionItems { get; set; } = new();
    }
}
