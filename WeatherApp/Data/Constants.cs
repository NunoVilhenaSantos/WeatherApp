﻿namespace WeatherApp.Data;

/// <summary>
/// </summary>
public static class Constants
{
    /// <summary>
    /// </summary>
    public const string OpenWeatherMapEndpoint =
        "https://api.openweathermap.org/data/2.5/weather";

    /// <summary>
    /// </summary>
    //  public const string OpenWeatherMapApiKey = "adee4d9d26685357054efd2f06359807";
    public const string OpenWeatherMapApiKey =
        "a03cc2b18493fe714b4b4750e20b883e";


    /// <summary>
    /// </summary>
    public const string IconUrlPrefix = "https://openweathermap.org/img/wn/";


    /// <summary>
    /// </summary>
    // https://api.openweathermap.org/geo/1.0/direct?q=London&limit=5&appid={API key}
    public const string OpenWeatherGeoEndpoint =
        "https://api.openweathermap.org/geo/1.0/direct";
}