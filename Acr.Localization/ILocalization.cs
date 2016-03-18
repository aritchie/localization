using System;
using System.Globalization;
using System.Threading.Tasks;


namespace Acr.Localization {

    public interface ILocalization
    {

        Task Initialize();

        string GetString(string key, params object[] args);
        string GetString(Enum value);
        string GetString(CultureInfo culture, string key, params object[] args);
        string GetString(CultureInfo culture, Enum value);

        /// <summary>
        /// Matches keys up with property names in supplied object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix">Allow a prefix against this class (ie. [TypeName.]LocalizationKey)</param>
        /// <param name="culture">Culture to use for binding - defaults to current culture</param>
        /// <param name="errorOnMissingKeys">Operation will throw an exception for properties that are missing a key</param>
        /// <returns></returns>
        T Bind<T>(string prefix = null, CultureInfo culture = null, bool errorOnMissingKeys = true) where T : class, new();


        /// <summary>
        /// Matches keys up with property names in supplied object
        /// </summary>
        /// <param name="obj">Instance to bind to</param>
        /// <param name="prefix">Allow a prefix against this class (ie. [TypeName.]LocalizationKey)</param>
        /// <param name="culture">Culture to use for binding - defaults to current culture</param>
        /// <param name="errorOnMissingKeys">Operation will throw an exception for properties that are missing a key</param>
        void Bind(object obj, string prefix = null, CultureInfo culture = null, bool errorOnMissingKeys = true);
    }
}
