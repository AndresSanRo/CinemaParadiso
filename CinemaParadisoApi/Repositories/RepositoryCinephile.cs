using CinemaParadisoApi.Data;
using CinemaParadisoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadisoApi.Repositories
{
    public class RepositoryCinephile : IRepositoryCinephile
    {
        ICinemaContext context;
        public RepositoryCinephile(ICinemaContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Checks if a login request is valid.
        /// </summary>
        /// <param name="user">String. User´s email.</param>
        /// <param name="password">String. User´s password.</param>
        /// <returns></returns>
        public bool Login(String user, String password)
        {
            Cinephile cineUser = (from data in context.Cinephiles
                        where data.Email.Equals(user)
                        && data.Password.Equals(password)
                        select data).FirstOrDefault();
            if (cineUser != null)            
                return true;
            else
                return false;
        }
        public bool CheckInList(int idMovie, String user)
        {
            Lists query = (from data in context.Lists
                          where data.IdMovie.Equals(idMovie)
                          && data.UserEmail.Equals(user)
                          select data).FirstOrDefault();
            if (query != null)
                return true;
            else
                return false;
        }
        public void AddMovieToList(int idMovie, String user)
        {
            Lists movie = new Lists();
            movie.IdMovie = idMovie;
            movie.UserEmail = user;
            context.Lists.Add(movie);
            context.SaveChanges();
        }
        public void RemoveMovieFromList(int idMovie, String user)
        {
            Lists movie = new Lists();
            movie.IdMovie = idMovie;
            movie.UserEmail = user;
            context.Lists.Remove(movie);
            context.SaveChanges();
        }
        public List<Lists> GetUserList(String user)
        {
            var query = from data in context.Lists
                        where data.UserEmail.Equals(user)
                        select data;
            return query.ToList();
        }
        public Cinephile GetUser(String user)
        {
            return context.Cinephiles.SingleOrDefault(z => z.Email.Equals(user));
        }
        public void RegisterUser(string email, string pass, string name, string lastName, int? age)
        {
            Cinephile newUser = new Cinephile();
            newUser.Email = email;
            newUser.Password = pass;
            newUser.Name = name;
            newUser.LastName = lastName;
            newUser.Age = age.GetValueOrDefault();
            context.Cinephiles.Add(newUser);
            context.SaveChanges();
        }
    }
}
