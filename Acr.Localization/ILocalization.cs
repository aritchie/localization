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
    }
}
