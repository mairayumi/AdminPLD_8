using Microsoft.AspNetCore.Identity;

namespace waPLD.Models.Catalogo.Usuario
{
    public class Usuarios : IdentityUser
    {
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public bool Bloqueo { get; set; }
        public string ReturnUrl { get; set; }
        public int UsrId { get; set; }

    }
}
