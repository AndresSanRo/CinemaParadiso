using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaParadisoApi.Models;
using CinemaParadisoApi.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CinemaParadisoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration configuration;
        IRepositoryCinephile repo;

        public AuthController(IRepositoryCinephile repo, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(Login model)
        {
            Cinephile user = this.repo.Login(model.UserName, model.Password);
            if (user != null)
            {
                //ESTA ES LA INFORMACION QUE VAMOS A INCLUIR EN 
                //NUESTRO TOKEN PARA PODER RECUPERARLA POSTERIORMENTE
                Claim[] claims = new[]
                {
                    new Claim("UserData", JsonConvert.SerializeObject(user))
                };

                //GENERAMOS EL TOKEN CON LA INFORMACION
                JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer: configuration["ApiAuth:Issuer"],
                    audience: configuration["ApiAuth:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApiAuth:SecretKey"])),
                    SecurityAlgorithms.HmacSha256)
                );

                // Devolvemos el token en la respuesta
                return Ok(
                    new
                    {
                        response = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}