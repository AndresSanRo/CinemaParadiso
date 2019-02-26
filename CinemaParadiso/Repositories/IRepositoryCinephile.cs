﻿using System;
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
    }
}
