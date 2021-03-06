﻿using CinemaParadisoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadisoApi.Data
{
    public class CinemaContext : DbContext, ICinemaContext
    {
        public CinemaContext(DbContextOptions options) : base(options) { }
        public DbSet<Cinephile> Cinephiles { get; set; }
        public DbSet<Lists> Lists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lists>()
                .HasKey(c => new { c.IdMovie, c.UserEmail });
        }
    }
}
