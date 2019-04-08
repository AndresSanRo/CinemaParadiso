using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaParadisoApi.Models;
using CinemaParadisoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaParadisoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinephileController : ControllerBase
    {
        IRepositoryCinephile repo;
        public CinephileController(IRepositoryCinephile repo)
        {
            this.repo = repo;
        }
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public Cinephile Get(String id)
        {
            Cinephile user = repo.GetUser(id);
            user.Password = null;
            return user;
        }
        [HttpPost]
        public void Post([FromBody]Cinephile user)
        {
            repo.RegisterUser(user.Email, user.Password, user.Name, user.LastName, user.Age);            
        }
    }
}