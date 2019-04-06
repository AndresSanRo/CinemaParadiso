using CinemaParadiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Repositories
{
    public interface IRepositoryCinephile
    {
        bool Login(String user, String password);
        bool CheckInList(int idMovie, String user);
        void AddMovieToList(int idMovie, String user);
        void RemoveMovieFromList(int idMovie, String user);
        List<Lists> GetUserList(String user);
        void RegisterUser(String email, String pass, String name, String lastName, int? age);
        Cinephile GetUser(String user);
    }
}
