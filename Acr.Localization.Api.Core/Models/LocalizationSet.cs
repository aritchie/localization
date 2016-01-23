using System;


namespace Acr.Localization.Api.Core.Models
{
    public class LocalizationSet
    {
        public virtual int Id { get; set; }
        // versioning?

        public virtual int AppId { get; set; }
        public virtual App App { get; set; }
    }
}
