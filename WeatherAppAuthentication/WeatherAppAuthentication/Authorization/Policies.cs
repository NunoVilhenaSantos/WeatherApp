﻿// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

namespace WeatherAppAuthentication.Authorization;

public class Policies
{
    ///<summary>Policy to allow viewing all user records.</summary>
    public const string ViewAllUsersPolicy = "View All Users";

    ///<summary>Policy to allow adding, removing and updating all user records.</summary>
    public const string ManageAllUsersPolicy = "Manage All Users";

    /// <summary>Policy to allow viewing details of all roles.</summary>
    public const string ViewAllRolesPolicy = "View All Roles";

    /// <summary>Policy to allow viewing details of all or specific roles (Requires roleName as parameter).</summary>
    public const string ViewRoleByRoleNamePolicy = "View Role by RoleName";

    /// <summary>Policy to allow adding, removing and updating all roles.</summary>
    public const string ManageAllRolesPolicy = "Manage All Roles";

    /// <summary>Policy to allow assigning roles the user has access to (Requires new and current roles as parameter).</summary>
    public const string AssignAllowedRolesPolicy = "Assign Allowed Roles";
}

/// <summary>
///     Operation Policy to allow adding, viewing, updating and deleting general or specific user records.
/// </summary>
public static class AccountManagementOperations
{
    public const string CreateOperationName = "Create";
    public const string ReadOperationName = "Read";
    public const string UpdateOperationName = "Update";
    public const string DeleteOperationName = "Delete";

    public static UserAccountAuthorizationRequirement Create =
        new(CreateOperationName);

    public static UserAccountAuthorizationRequirement Read =
        new(ReadOperationName);

    public static UserAccountAuthorizationRequirement Update =
        new(UpdateOperationName);

    public static UserAccountAuthorizationRequirement Delete =
        new(DeleteOperationName);
}