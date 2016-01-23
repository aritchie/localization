using System;
using System.Globalization;
using System.Threading.Tasks;
using Acr.Localization.Api.Client.ViewModels;
using Flurl;


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
            this.package = await this.BaseUrl
                .AppendPathSegment(this.AppName)
                .ReceiveJson<LocalizationPackage>();
        }


        protected override string GetValue(string key, CultureInfo cultureInfo)
        {
            // TODO: make sure we have this package for this locale
            return String.Empty;
        }
    }
}
