// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeatherAppAuthentication.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SanitizeModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var arg in context.ActionArguments.Values)
            if (arg is ISanitizeModel model)
                model.SanitizeModel();
    }
}

public interface ISanitizeModel
{
    public void SanitizeModel();
}