using System;


namespace Acr.Localization.Api.Core.Models
{
    public class Locale
    {
        public virtual int Id { get; set; }
        public virtual string AccessCode { get; set; } // TODO: fr or fr-CA
    }
}
