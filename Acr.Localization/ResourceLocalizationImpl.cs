using System;
using System.Globalization;
using System.Reflection;
using System.Resources;


namespace Acr.Localization
{

    public class ResourceLocalizationImpl : AbstractLocalizationImpl
    {
        readonly ResourceManager resourceManager;


        public ResourceLocalizationImpl(string baseName, Assembly assembly)
        {
            this.resourceManager = new ResourceManager(baseName, assembly);
        }


        protected override string GetValue(string key, CultureInfo cultureInfo)
        {
            return this.resourceManager.GetString(key, cultureInfo);
        }
    }
}
