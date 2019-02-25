using CinemaParadiso.Data;
using CinemaParadiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Repositories
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
    }
}
