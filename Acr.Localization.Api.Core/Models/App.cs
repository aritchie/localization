using System;
using System.Collections.Generic;


namespace Acr.Localization.Api.Core.Models
{
    public class App
    {
        public virtual int Id { get; set; }
        public virtual string AccessKey { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual ICollection<LocalizedValue> LocalizedValues { get; set; }
    }
}
