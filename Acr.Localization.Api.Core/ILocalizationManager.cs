using System;
using System.Threading.Tasks;
using Acr.Localization.Api.Client.ViewModels;


namespace Acr.Localization.Api.Core
{
    public interface ILocalizationManager
    {
        Task<LocalizationPackage> GetPackage(string appName, string localeCode);
    }
}
