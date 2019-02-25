using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaParadiso.Controllers
{
    public class ValidationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string user, string password)
        {
            //Aqui se comprueban los usuarios (BBDD)
            if (user.ToLower().Equals("admin") && password.ToLower().Equals("admin"))
            {
                //Creamos la identidad
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.PostalCode, "28300"));
                identity.AddClaim(new Claim(ClaimTypes.Name, user));
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.Now.AddMinutes(30) });
                return RedirectToAction("Index", "Profile");
            }
            ViewData["Mensaje"] = "Usuario/Password incorrecto";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}