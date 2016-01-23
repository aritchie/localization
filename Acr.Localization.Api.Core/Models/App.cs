using System;


namespace Acr.Localization.Api.Core.Models
{
    public class App
    {
        public virtual int Id { get; set; }
        public virtual string AccessKey { get; set; }
        public virtual string Description { get; set; }
        public virtual string ClientSecret { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
