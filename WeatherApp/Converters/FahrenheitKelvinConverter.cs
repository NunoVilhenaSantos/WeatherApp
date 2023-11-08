using System.Globalization;

namespace WeatherApp.Converters;

/// <summary>
/// </summary>
public class FahrenheitKelvinConverter : IValueConverter
{
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        var fahrenheit = (double) value;
        var kelvin = 0.00;

        if (!Equals(fahrenheit, null))
            kelvin = (fahrenheit - 32) * 5 / 9 + 273.15;

        return Math.Round(kelvin).ToString(culture);
    }


    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object ConvertBack(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        var fahrenheit = 0.00;
        var kelvin = (double) value;

        if (!Equals(kelvin, null))
            kelvin = (kelvin - 273.15) * 9 / 5 + 32;

        return Math.Round(fahrenheit).ToString(culture);
    }
}