﻿namespace RedBerylBookStore.Data
{
    using DataModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Configuration;

    public class ApplicationDbContext : DbContext
    {
        private readonly string connectionString;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            IConfiguration configuration) : base(options)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, builder => builder.EnableRetryOnFailure())
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<Book>().HasQueryFilter(x => x.IsActive);
        }
    }
}