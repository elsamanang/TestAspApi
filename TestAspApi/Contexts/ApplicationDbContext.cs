﻿using Microsoft.EntityFrameworkCore;
using TestAspApi.Models;

namespace TestAspApi.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TestAspApi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Auteur> Auteurs { get; set; }
        public virtual DbSet<Livre> Livres { get; set; }
    }
}
