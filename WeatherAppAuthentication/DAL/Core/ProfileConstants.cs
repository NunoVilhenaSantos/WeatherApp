﻿// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

namespace DAL.Core;

public static class ClaimConstants
{
    ///<summary>A claim that specifies the subject of an entity</summary>
    public const string Subject = "sub";

    ///<summary>A claim that specifies the permission of an entity</summary>
    public const string Permission = "permission";
}

public static class PropertyConstants
{
    ///<summary>A property that specifies the full name of an entity</summary>
    public const string FullName = "fullname";

    ///<summary>A property that specifies the job title of an entity</summary>
    public const string JobTitle = "jobtitle";

    ///<summary>A property that specifies the configuration/customizations of an entity</summary>
    public const string Configuration = "configuration";
}