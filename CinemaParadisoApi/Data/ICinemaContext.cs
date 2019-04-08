using CinemaParadisoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadisoApi.Data
{
    public interface ICinemaContext
    {
        DbSet<Cinephile> Cinephiles { get; set; }
        DbSet<Lists> Lists { get; set; }
        int SaveChanges();
    }
}
