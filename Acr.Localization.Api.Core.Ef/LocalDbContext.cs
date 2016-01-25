using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Reflection;
using Acr.Localization.Api.Core.Models;


namespace Acr.Localization.Api.Core.Ef
{
    public class LocalDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var pluralization = DbConfiguration.DependencyResolver.GetService<IPluralizationService>();

            modelBuilder
                .Types()
                .Configure(x => {
                    var tableName = pluralization.Pluralize(x.ClrType.Name);
                    x.ToTable(tableName);
                    x.Property("Id").HasColumnName(x.ClrType.Name + "Id");
                });

            modelBuilder
                .Properties<int>()
                .Where(x => x.Name == "Id")
                .Configure(x => x
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsKey()
                );

            modelBuilder
                .Properties<string>()
                .Configure(x => x
                    .HasMaxLength(50)
                    .IsRequired()
                );
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<App> Apps { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<LocalizedValue> LocalizedValues { get; set; }
    }
}
