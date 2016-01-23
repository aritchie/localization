using System;
using System.Data.Entity;
using System.Reflection;
using Acr.Localization.Api.Core.Models;


namespace Acr.Localization.Api.Core.Ef
{
    public class LocalDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<App> Apps { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<LocalizedValue> LocalizedValues { get; set; }
    }
}
