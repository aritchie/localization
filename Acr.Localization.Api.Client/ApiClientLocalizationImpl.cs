using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acr.Localization.Api.Client {

    public class ApiClientLocalizationImpl : AbstractLocalizationImpl {
        public string Url { get; set; }

        public ApiClientLocalizationImpl(string url)
        {
            this.Url = url;
        }


        public override async Task Initialize()
        {
            throw new NotImplementedException();
        }


        protected override string GetValue(string key, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
