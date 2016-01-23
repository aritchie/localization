using System;


namespace Acr.Localization.Api.Core.Models
{
    public class LocalizedValue
    {
        public virtual int Id { get; set; }
        public virtual string AccessKey { get; set; }
        public virtual string Value { get; set; }
    
        public virtual int AppId { get; set; }
        public virtual App App { get; set; }

        public virtual int LocaleId { get; set; }
        public virtual Locale Locale { get; set; }
    }
}
