﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace WeatherAppAuthentication.DAL.CompiledModels
{
    public partial class ApplicationDbContextModel
    {
        partial void Initialize()
        {
            var applicationRole = ApplicationRoleEntityType.Create(this);
            var applicationUser = ApplicationUserEntityType.Create(this);
            var customer = CustomerEntityType.Create(this);
            var order = OrderEntityType.Create(this);
            var orderDetail = OrderDetailEntityType.Create(this);
            var product = ProductEntityType.Create(this);
            var productCategory = ProductCategoryEntityType.Create(this);
            var identityRoleClaim = IdentityRoleClaimEntityType.Create(this);
            var identityUserClaim = IdentityUserClaimEntityType.Create(this);
            var identityUserLogin = IdentityUserLoginEntityType.Create(this);
            var identityUserRole = IdentityUserRoleEntityType.Create(this);
            var identityUserToken = IdentityUserTokenEntityType.Create(this);
            var openIddictEntityFrameworkCoreApplication = OpenIddictEntityFrameworkCoreApplicationEntityType.Create(this);
            var openIddictEntityFrameworkCoreAuthorization = OpenIddictEntityFrameworkCoreAuthorizationEntityType.Create(this);
            var openIddictEntityFrameworkCoreScope = OpenIddictEntityFrameworkCoreScopeEntityType.Create(this);
            var openIddictEntityFrameworkCoreToken = OpenIddictEntityFrameworkCoreTokenEntityType.Create(this);

            OrderEntityType.CreateForeignKey1(order, applicationUser);
            OrderEntityType.CreateForeignKey2(order, customer);
            OrderDetailEntityType.CreateForeignKey1(orderDetail, order);
            OrderDetailEntityType.CreateForeignKey2(orderDetail, product);
            ProductEntityType.CreateForeignKey1(product, product);
            ProductEntityType.CreateForeignKey2(product, productCategory);
            IdentityRoleClaimEntityType.CreateForeignKey1(identityRoleClaim, applicationRole);
            IdentityUserClaimEntityType.CreateForeignKey1(identityUserClaim, applicationUser);
            IdentityUserLoginEntityType.CreateForeignKey1(identityUserLogin, applicationUser);
            IdentityUserRoleEntityType.CreateForeignKey1(identityUserRole, applicationRole);
            IdentityUserRoleEntityType.CreateForeignKey2(identityUserRole, applicationUser);
            IdentityUserTokenEntityType.CreateForeignKey1(identityUserToken, applicationUser);
            OpenIddictEntityFrameworkCoreAuthorizationEntityType.CreateForeignKey1(openIddictEntityFrameworkCoreAuthorization, openIddictEntityFrameworkCoreApplication);
            OpenIddictEntityFrameworkCoreTokenEntityType.CreateForeignKey1(openIddictEntityFrameworkCoreToken, openIddictEntityFrameworkCoreApplication);
            OpenIddictEntityFrameworkCoreTokenEntityType.CreateForeignKey2(openIddictEntityFrameworkCoreToken, openIddictEntityFrameworkCoreAuthorization);

            ApplicationRoleEntityType.CreateAnnotations(applicationRole);
            ApplicationUserEntityType.CreateAnnotations(applicationUser);
            CustomerEntityType.CreateAnnotations(customer);
            OrderEntityType.CreateAnnotations(order);
            OrderDetailEntityType.CreateAnnotations(orderDetail);
            ProductEntityType.CreateAnnotations(product);
            ProductCategoryEntityType.CreateAnnotations(productCategory);
            IdentityRoleClaimEntityType.CreateAnnotations(identityRoleClaim);
            IdentityUserClaimEntityType.CreateAnnotations(identityUserClaim);
            IdentityUserLoginEntityType.CreateAnnotations(identityUserLogin);
            IdentityUserRoleEntityType.CreateAnnotations(identityUserRole);
            IdentityUserTokenEntityType.CreateAnnotations(identityUserToken);
            OpenIddictEntityFrameworkCoreApplicationEntityType.CreateAnnotations(openIddictEntityFrameworkCoreApplication);
            OpenIddictEntityFrameworkCoreAuthorizationEntityType.CreateAnnotations(openIddictEntityFrameworkCoreAuthorization);
            OpenIddictEntityFrameworkCoreScopeEntityType.CreateAnnotations(openIddictEntityFrameworkCoreScope);
            OpenIddictEntityFrameworkCoreTokenEntityType.CreateAnnotations(openIddictEntityFrameworkCoreToken);

            AddAnnotation("ProductVersion", "7.0.13");
            AddAnnotation("Relational:MaxIdentifierLength", 128);
            AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
