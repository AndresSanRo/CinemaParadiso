using CinemaParadiso.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Data
{
    public class CinemaContext : DbContext, ICinemaContext
    {
        public CinemaContext(DbContextOptions options) : base(options) { }
        public DbSet<Cinephile> Cinephiles { get; set; }
        public DbSet<Lists> Lists { get; set; }
    }
}
