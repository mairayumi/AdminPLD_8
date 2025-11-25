using Microsoft.AspNetCore.Identity;

namespace wsPLD_8.Models.Shared
{
    public class Usuarios : IdentityUser
    {
        //public string? Password { get; set; }
        //public bool? RememberMe { get; set; }
        //public bool? Bloqueo { get; set; }
        //public string? ReturnUrl { get; set; }
        public int UsrId { get; set; }
        public string Discriminator { get; set; }
    }
}
