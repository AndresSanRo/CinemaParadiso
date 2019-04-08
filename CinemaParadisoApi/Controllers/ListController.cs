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
    [Authorize]
    public class ListController : ControllerBase
    {
        IRepositoryCinephile repo;
        public ListController(IRepositoryCinephile repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Route("GetUserList")]        
        public List<Lists> GetUserList([FromQuery]String user)
        {
            return repo.GetUserList(user);
        }
        [HttpGet]
        [Route("CheckInList")]
        public IActionResult CheckInList([FromQuery]int idMovie, [FromQuery]String user)
        {
            if (repo.CheckInList(idMovie, user))
                return Ok();
            else
                return NotFound();
        }
        [HttpPost]
        [Route("AddMovieToList")]
        public void AddMovieToList([FromBody]Lists list)
        {
            repo.AddMovieToList(list.IdMovie, list.UserEmail);
        }
        [HttpPost]
        [Route("RemoveMovieFromList")]
        public void RemoveMovieFromList([FromBody] Lists list)
        {
            repo.RemoveMovieFromList(list.IdMovie, list.UserEmail);
        }
    }
}