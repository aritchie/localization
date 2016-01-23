using System;
using System.Globalization;
using System.Threading.Tasks;
using Acr.Localization.Api.Client.ViewModels;
using Flurl;
using Flurl.Http;


namespace Acr.Localization.Api.Client {

    public class ApiClientLocalizationImpl : AbstractLocalizationImpl {
        public string BaseUrl { get; set; }
        public string AppName { get; set; }
        LocalizationPackage package;


        public ApiClientLocalizationImpl(string baseUrl, string appName)
        {
            this.BaseUrl = baseUrl;
            this.AppName = appName;
        }


        public override async Task Initialize()
        {
            // TODO: could monitor locale change to swap this
            // TODO: write to local cache with expiration date
            // TODO: always check cache first
            this.package = await this.BaseUrl
                .AppendPathSegment(this.AppName)
                .GetJsonAsync<LocalizationPackage>();
        }


        protected override string GetValue(string key, CultureInfo cultureInfo)
        {
            // TODO: make sure we have this package for this locale
            return String.Empty;
        }
    }
}
