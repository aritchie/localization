using System;
using System.Collections.Generic;


namespace Acr.Localization.Api.Client.ViewModels
{
    public class LocalizationPackage
    {
        public string AppName { get; set; }
        public string LocaleCode { get; set; }
        public Dictionary<string, string> Values { get; set; } 
    }
}
