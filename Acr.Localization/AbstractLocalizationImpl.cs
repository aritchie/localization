using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Acr.Localization {

    public abstract class AbstractLocalizationImpl : ILocalization {

        protected abstract string GetValue(string key, CultureInfo cultureInfo);


        public virtual T Bind<T>(string prefix = null, CultureInfo culture = null, bool errorOnMissingKeys = true) where T : class, new()
        {
            var obj = new T();
            this.Bind(obj, prefix, culture, errorOnMissingKeys);
            return obj;
        }


        public virtual void Bind(object obj, string prefix = null, CultureInfo culture = null, bool errorOnMissingKeys = true)
        {
            var props = obj
                .GetType()
                .GetTypeInfo()
                .DeclaredProperties
                .Where(x =>
                    x.CanRead &&
                    x.CanWrite &&
                    x.PropertyType == typeof(string)
                );

            prefix = prefix ?? String.Empty;
            foreach (var prop in props)
            {
                var value = this.GetValue(prefix + prop.Name, culture);
                if (value != null)
                    prop.SetValue(obj, value);

                else
                {
                    if (errorOnMissingKeys)
                        throw new ArgumentException($"Missing localization key for {obj.GetType().FullName} - {prefix}{prop.Name}");

                    prop.SetValue(obj, $"ERROR: {prefix}{prop.Name}");
                }
            }
        }


        public virtual Task Initialize()
        {
            return Task.FromResult<object>(null);
        }


        public virtual string GetString(string key, params object[] args)
        {
            return this.GetString(CultureInfo.CurrentCulture, key, args);
        }


        public virtual string GetString(Enum value)
        {
            return this.GetString(CultureInfo.CurrentCulture, value);
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
    }
}
