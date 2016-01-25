using System;
using System.Threading.Tasks;
using System.Web.Http;
using Acr.Localization.Api.Core;

namespace Acr.Localization.Api.Controllers
{
    public class RootController : ApiController
    {
        readonly ILocalizationManager localizationManager;

        public RootController(ILocalizationManager localizationManager)
        {
            this.localizationManager = localizationManager;
        }


        [HttpGet]
        [Route("~/{appName}/{locale}")]
        public async Task<IHttpActionResult> Get(string appName, string localeCode)
        {
            var result = await this.localizationManager.GetPackage(appName, localeCode);
            return this.Ok(result);
        }
    }
}
