// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WeatherAppAuthentication.ViewModels;

namespace WeatherAppAuthentication.Helpers;

public static class Extensions
{
    // HttpResponse
    public static void AddPagination(this HttpResponse response,
        int currentPage, int itemsPerPage, int totalItems, int totalPages)
    {
        response.Headers.Add("Pagination",
            JsonConvert.SerializeObject(new PageHeader(currentPage,
                itemsPerPage, totalItems, totalPages)));
        response.Headers.Add("access-control-expose-headers",
            "Pagination"); // CORS
    }

    public static void AddApplicationError(this HttpResponse response,
        string message)
    {
        response.Headers.Add("Application-Error", message);
        response.Headers.Add("access-control-expose-headers",
            "Application-Error"); // CORS
    }

    // string
    public static string NullIfWhiteSpace(this string value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value;
    }

    // Array
    public static T[] NullIfEmpty<T>(this T[] value)
    {
        return value?.Any() == true ? value : null;
    }
}