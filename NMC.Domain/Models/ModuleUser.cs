using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public class ModuleUser
    {
        public int Id { get; set; }
        
        
        [Display(Name = "Module")]
        public ModuleName Module { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Received")]
        public bool ReceiveNotification { get; set; }
    }
}
