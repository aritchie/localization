using System;
using System.Threading.Tasks;
using Acr.Localization.Api.Client.ViewModels;


namespace Acr.Localization.Api.Core.Ef
{
    public class LocalizationManagerImpl : ILocalizationManager
    {
        readonly LocalDbContext data;


        public LocalizationManagerImpl(LocalDbContext data)
        {
            this.data = data;
        }

        public Task<LocalizationPackage> GetPackage(string appName, string localeCode)
        {
            throw new NotImplementedException();
        }
    }
}
