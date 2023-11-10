﻿// <auto-generated />
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using OpenIddict.EntityFrameworkCore.Models;

#pragma warning disable 219, 612, 618
#nullable disable

namespace WeatherAppAuthentication.DAL.CompiledModels
{
    internal partial class OpenIddictEntityFrameworkCoreApplicationEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreApplication",
                typeof(OpenIddictEntityFrameworkCoreApplication),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var clientId = runtimeEntityType.AddProperty(
                "ClientId",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("ClientId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<ClientId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 100);
            clientId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var clientSecret = runtimeEntityType.AddProperty(
                "ClientSecret",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("ClientSecret", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<ClientSecret>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            clientSecret.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var concurrencyToken = runtimeEntityType.AddProperty(
                "ConcurrencyToken",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("ConcurrencyToken", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<ConcurrencyToken>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                concurrencyToken: true,
                maxLength: 50);
            concurrencyToken.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var consentType = runtimeEntityType.AddProperty(
                "ConsentType",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("ConsentType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<ConsentType>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);
            consentType.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var displayName = runtimeEntityType.AddProperty(
                "DisplayName",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("DisplayName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<DisplayName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            displayName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var displayNames = runtimeEntityType.AddProperty(
                "DisplayNames",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("DisplayNames", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<DisplayNames>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            displayNames.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var permissions = runtimeEntityType.AddProperty(
                "Permissions",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("Permissions", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<Permissions>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            permissions.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var postLogoutRedirectUris = runtimeEntityType.AddProperty(
                "PostLogoutRedirectUris",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("PostLogoutRedirectUris", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<PostLogoutRedirectUris>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            postLogoutRedirectUris.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var properties = runtimeEntityType.AddProperty(
                "Properties",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("Properties", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<Properties>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            properties.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var redirectUris = runtimeEntityType.AddProperty(
                "RedirectUris",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("RedirectUris", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<RedirectUris>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            redirectUris.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var requirements = runtimeEntityType.AddProperty(
                "Requirements",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("Requirements", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<Requirements>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            requirements.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, OpenIddictEntityFrameworkCoreAuthorization, OpenIddictEntityFrameworkCoreToken>).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);
            type.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { clientId },
                unique: true);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "OpenIddictApplications");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}