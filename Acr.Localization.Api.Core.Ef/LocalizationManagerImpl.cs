using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Acr.Localization.Api.Core.Ef
{
    public class LocalizationManagerImpl : ILocalizationManager
    {
        readonly LocalDbContext data;


        public LocalizationManagerImpl(LocalDbContext data)
        {
            this.data = data;
        }
    }
}
