using System;
using System.Data.Entity.ModelConfiguration;
using Acr.Localization.Api.Core.Models;


namespace Acr.Localization.Api.Core.Ef.Mapping
{
    public class AppMap : EntityTypeConfiguration<App>
    {
        public AppMap()
        {
            this.Property(x => x.AccessKey);
            this.Property(x => x.IsActive);

            this.HasMany(x => x.LocalizedValues)
                .WithRequired(x => x.App)
                .HasForeignKey(x => x.AppId);
        }
    }
}
