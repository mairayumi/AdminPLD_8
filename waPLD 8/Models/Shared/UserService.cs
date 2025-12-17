using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using waPLD.Models.Catalogo.Usuario;

namespace waPLD.Models.Shared
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
        Task<string> Alta(string username, string password, string email);
    }
    public class UserService : IUserService
    {
        public IConfiguration Configuration { get; }
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(IConfiguration configuration
                           , UserManager<IdentityUser> userManager)
        {
            Configuration = configuration;
            _userManager = userManager;
        }
        public async Task<string> Authenticate(string username, string password)
        {
            try
            {            
            var user = await _userManager.FindByEmailAsync(username);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception Ex)
            {
                var vadena = Ex.Message;
                throw;
            }                 
        }

        public async Task<string> Alta(string username, string password,string email)
        {
            Usuarios usuario = new Usuarios();
            usuario.UserName = username;
            usuario.NormalizedUserName = username;
            usuario.Email = email;
            usuario.NormalizedEmail = email;
            usuario.Password = password;
            usuario.LockoutEnabled = true;
            usuario.UsrId = 5;
            var result = await _userManager.CreateAsync(usuario);
            return "Exitoso";
        }

    }
}