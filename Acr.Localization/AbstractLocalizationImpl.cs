using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Acr.Localization {

    public abstract class AbstractLocalizationImpl : ILocalization {

        public virtual Task Initialize()
        {
            return Task.FromResult<object>(null);
        }


        protected abstract string GetValue(string key, CultureInfo cultureInfo);


        protected virtual string Format(string value, object[] args)
        {
            if (args?.Length > 0)
                value = String.Format(value, args);

            return value;
        }


        protected virtual string GetEnumKey(Enum value)
        {
            var t = value.GetType();
            var key = $"{t.Namespace}.{t.Name}.{value}";
            return key;
        }


        public virtual string GetString(string key, params object[] args)
        {
            return this.GetString(null, key, args);
        }


        public virtual string GetString(Enum value)
        {
            return this.GetString(null, value);
        }


        public virtual string GetString(CultureInfo culture, string key, params object[] args)
        {
            var r = this.GetValue(key, culture);
            if (r == null)
                return "ERROR: " + key;

            return this.Format(r, args);
        }


        public virtual string GetString(CultureInfo culture, Enum value)
        {
            var key = this.GetEnumKey(value);
            return this.GetString(culture, key);
        }
    }
}
