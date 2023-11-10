// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using Microsoft.Extensions.Logging;

namespace WeatherAppAuthentication.Helpers;

public static class LoggingEvents
{
    public static readonly EventId INIT_DATABASE =
        new(101, "Error whilst creating and seeding database");

    public static readonly EventId SEND_EMAIL =
        new(201, "Error whilst sending email");
}