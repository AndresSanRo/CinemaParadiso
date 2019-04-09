using CinemaParadiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Repositories
{
    public interface IRepositoryCinephile
    {
        String token { get; set; }
        Task<T> CallApi<T>(String peticion);
        Task<String> Login(String user, String password);
        Task<bool> CheckInList(int idMovie, String user);
        Task AddMovieToList(int idMovie, String user);
        Task RemoveMovieFromList(int idMovie, String user);
        Task<List<Lists>> GetUserList(String user);
        Task RegisterUser(String email, String pass, String name, String lastName, int? age);
        Task<Cinephile> GetUser(String user);
    }
}
