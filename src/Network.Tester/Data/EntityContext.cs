using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Mx.EntityFramework.Contracts;
using Network.Tester.Models;

namespace Network.Tester.Data
{
    public class EntityContext : DbContext, IEntityContext
    {
        private readonly string _connectionString;
        private const string DefaultSchema = "dbo";
        private const string ConfigurationSchema = "configuration";

        public EntityContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbContext Context => this;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(15),
                        errorNumbersToAdd: new Collection<int>());
                });
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Corp>()
             //   .ToTable("Corp", ConfigurationSchema);

             modelBuilder.Entity<Winery>()
                 .ToTable("Winery", DefaultSchema);
        }
    }
}