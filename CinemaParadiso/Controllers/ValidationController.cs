using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaParadiso.Filters;
using CinemaParadiso.Models;
using CinemaParadiso.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaParadiso.Controllers
{
    public class ValidationController : Controller
    {
        IRepositoryCinephile repo;
        public ValidationController(IRepositoryCinephile repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(String user, String password)
        {
            //Aqui se comprueban los usuarios (BBDD)
            if (repo.Login(user, password))
            {
                //Creamos la identidad
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, null);                
                identity.AddClaim(new Claim(ClaimTypes.Name, user));                
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.Now.AddMinutes(30) });
                return RedirectToAction("Index", "Home");
            }
            ViewData["Mensaje"] = "Usuario/Password incorrecto";
            return View();
        }
        [UserAuthorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string email, string pass, string rPass, string name, string lastName, int? age)
        {
            if (email is null || pass is null || rPass is null)
            {
                ViewData["ERROR"] = "Rellena los campos obligatorios";
                return View();
            }
            if (!pass.Equals(rPass))
            {
                ViewData["ERROR"] = "Las contraseñas deben coincidir";
                return View();
            }            
            repo.RegisterUser(email, pass, name, lastName, age.GetValueOrDefault());
            return RedirectToAction("Login");
        }
    }
}