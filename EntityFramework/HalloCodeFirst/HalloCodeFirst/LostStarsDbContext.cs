﻿using HalloCodeFirst.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HalloCodeFirst
{
    public class LostStarsDbContext : DbContext
    {
        public LostStarsDbContext() : this("name=LostStarConnectionString")
        { }
        public LostStarsDbContext(string nameOrConnectionString) : base(nameOrConnectionString) => Configuration.LazyLoadingEnabled = false;

        public DbSet<Galaxy> Galaxies { get; set; }
        public DbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<Conventions.ForSqlServerDateTimeToDateConvention>();
            modelBuilder.Conventions.Add<Conventions.StringConventions>();
            modelBuilder.Conventions.Add<Conventions.TimestampConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new Configurations.GalaxyConfiguration());
            modelBuilder.Configurations.Add(new Configurations.StarConfiguration());
        }
    }
}
