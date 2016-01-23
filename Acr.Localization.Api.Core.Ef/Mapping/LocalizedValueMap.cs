using System;
using System.Data.Entity.ModelConfiguration;
using Acr.Localization.Api.Core.Models;


namespace Acr.Localization.Api.Core.Ef.Mapping
{
    public class LocalizedValueMap : EntityTypeConfiguration<LocalizedValue>
    {

        public LocalizedValueMap()
        {
            
        }
    }
}
