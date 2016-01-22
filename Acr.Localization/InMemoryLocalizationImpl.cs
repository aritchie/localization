using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acr.Localization {

    public class InMemoryLocalizationImpl : AbstractLocalizationImpl
    {
        readonly IDictionary<string, string> values;


        public InMemoryLocalizationImpl(IDictionary<string, string> values)
        {
            this.values = values;
        }


        protected override string GetValue(string key, CultureInfo cultureInfo)
        {
            return this.values[key];
        }
    }
}
