namespace SBMenu
{
    public class SBMenuSectionItem
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public SBMenuSection Section { get; set; }
        public int? MenuItemId { get; set; }
        public SBMenuItem MenuItem { get; set; }
        public int SortKey { get; set; }
    }
}
