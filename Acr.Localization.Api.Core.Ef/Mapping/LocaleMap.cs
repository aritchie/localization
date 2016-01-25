using System;
using System.Data.Entity.ModelConfiguration;
using Acr.Localization.Api.Core.Models;


namespace Acr.Localization.Api.Core.Ef.Mapping
{
    public class LocaleMap : EntityTypeConfiguration<Locale>
    {

        public LocaleMap()
        {
            this.Property(x => x.AccessCode);
            this.HasMany(x => x.LocalizedValues)
                .WithRequired(x => x.Locale)
                .HasForeignKey(x => x.LocaleId);
        }
    }
}
