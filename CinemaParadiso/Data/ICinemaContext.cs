using CinemaParadiso.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Data
{
    public interface ICinemaContext
    {
        DbSet<Cinephile> Cinephiles { get; set; }
        int SaveChanges();
    }
}
