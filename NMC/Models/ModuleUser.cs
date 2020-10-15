namespace NMC.Models
{
    public class ModuleUser
    {
        public int Id { get; set; }
        public ModuleName Module { get; set; }
        public string Username { get; set; }
        public bool ReceiveNotification { get; set; }
    }
}
