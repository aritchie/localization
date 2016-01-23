using System;
using System.Collections.Generic;


namespace Acr.Localization.Api.Core.Models
{
    public class Locale
    {
        public virtual int Id { get; set; }
        public virtual string AccessCode { get; set; } // TODO: fr or fr-CA
        public virtual ICollection<LocalizedValue> LocalizedValues { get; set; } 
    }
}
