// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System.ComponentModel.DataAnnotations;
using WeatherAppAuthentication.Helpers;

namespace WeatherAppAuthentication.ViewModels;

public class RoleViewModel : ISanitizeModel
{
    public string Id { get; set; }

    [Required(ErrorMessage = "Role name is required")]
    [StringLength(200, MinimumLength = 2,
        ErrorMessage = "Role name must be between 2 and 200 characters")]
    public string Name { get; set; }

    public string Description { get; set; }

    public int UsersCount { get; set; }

    public PermissionViewModel[] Permissions { get; set; }

    public virtual void SanitizeModel()
    {
        Id = Id.NullIfWhiteSpace();
        Name = Name.NullIfWhiteSpace();
        Description = Description.NullIfWhiteSpace();
    }
}