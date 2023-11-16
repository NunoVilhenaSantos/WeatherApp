// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace WeatherAppAuthentication;

public class OidcServerManager
{
    public const string ApiFriendlyName = "WeatherAppAuthentication API";
    public const string QuickAppClientID = "quickapp_spa";
    public const string SwaggerClientID = "swagger_ui";


    public static async Task RegisterApplicationsAsync(
        IServiceProvider provider)
    {
        var manager =
            provider.GetRequiredService<IOpenIddictApplicationManager>();


        // Angular SPA Client
        if (await manager.FindByClientIdAsync(QuickAppClientID) is null)
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = QuickAppClientID,
                Type = ClientTypes.Public,
                DisplayName = "WeatherAppAuthentication SPA",
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.GrantTypes.Password,
                    Permissions.GrantTypes.RefreshToken,
                    Permissions.Scopes.Profile,
                    Permissions.Scopes.Email,
                    Permissions.Scopes.Phone,
                    Permissions.Scopes.Address,
                    Permissions.Scopes.Roles
                }
            });


        // Swagger UI Client
        if (await manager.FindByClientIdAsync(SwaggerClientID) is null)
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = SwaggerClientID,
                Type = ClientTypes.Public,
                DisplayName = "Swagger UI",
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.GrantTypes.Password
                }
            });
    }
}