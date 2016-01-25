using System;
using System.Data.Entity.ModelConfiguration;
using Acr.Localization.Api.Core.Models;


namespace Acr.Localization.Api.Core.Ef.Mapping
{
    public class LocalizedValueMap : EntityTypeConfiguration<LocalizedValue>
    {
        public LocalizedValueMap()
        {
            // TODO: unique key - accesskey, localeid, appid
            this.Property(x => x.AccessKey);
            this.Property(x => x.Value)
                .HasMaxLength(null);

            this.HasRequired(x => x.Locale)
                .WithMany(x => x.LocalizedValues)
                .HasForeignKey(x => x.LocaleId);

            this.HasRequired(x => x.App)
                .WithMany(x => x.LocalizedValues)
                .HasForeignKey(x => x.AppId);
        }
    }
}
