// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using wsPLD_8.Extesion;
using wsPLD_8.Models.Shared;

namespace wsPLD_8.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel

    {
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private Aplicacion<int> _aplicacion;

        public LoginModel(
            SignInManager<Usuarios> signInManager
            ,ILogger<LoginModel> logger
            ,Aplicacion<int> aplicacion)
        {
            _signInManager = signInManager;
            //_userManager = userManager; 
            _logger = logger;
            _aplicacion = aplicacion;
            //_userManager = userManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "El campo de contraseña es necesario, te llegara por correo.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }

            [Display(Name = "Remember me?")]
            public int UsrId { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            string sAplicacion = HttpContext.Session.GetString("Aplicacion");
            if (sAplicacion != null)
            {
                _aplicacion = _aplicacion.Deserializar(sAplicacion);
            }
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            //&& Password.Equals(Input.Password)
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                Boolean valido = _aplicacion.UsrPassword.Equals(Input.Password);
                Input.Password = "Rpatria#01";
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded && valido)
                {
                    _aplicacion.ValidaUser(true);
                    HttpContext.Session.SetString("Aplicacion", _aplicacion.Serializar());
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }else if (Input.Email != null)
            {
                using (var User = _signInManager.UserManager.FindByEmailAsync(Input.Email))
                {
                    if (User != null) {
                        HTMLEmail htmlEmail = new HTMLEmail();
                        string contraseña = WebUtility.HtmlEncode(MyExtensions.GenerarContraseña(10));

                        htmlEmail.Read("?" +
                            "Mail_Para=" + User.Result.NormalizedEmail +
                            "&Asunto=Validacion de acceso" +
                            "&Titulo=Se comparte la contraseña de un solo acceso" +
                            "&SubTitulo=Vigente por 12 hrs" +
                            "&DirigidoA=" + User.Result.NormalizedEmail.Split('@')[0] +
                            "&Body=Favor de colocar la contraseña siguiente en su pantalla de inicio " +
                            "<H1>" + contraseña + "</H1>");
                        _aplicacion.UsrMessage = "La contraseña se recibe por correo";
                        _aplicacion.UsrPassword = contraseña;
                        _aplicacion.UsrId = User.Result.UsrId;
                        _aplicacion.NormalizedUsrName = User.Result.NormalizedUserName;
                        _aplicacion.UsrName = User.Result.UserName;
                        _aplicacion.UsrImg = "usr-" + User.Result.UsrId + "-128x128.jpg";
                        HttpContext.Session.SetString("Aplicacion", _aplicacion.Serializar());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Usuario invalido.");
                        return Page();
                    }
                }
               
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
