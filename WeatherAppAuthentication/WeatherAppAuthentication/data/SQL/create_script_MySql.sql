CREATE TABLE `AppCustomers`
(
    `Id`           int          NOT NULL AUTO_INCREMENT,
    `Name`         varchar(100) NOT NULL,
    `Email`        varchar(100) NULL,
    `PhoneNumber`  varchar(30)  NULL,
    `Address`      longtext     NULL,
    `City`         varchar(50)  NULL,
    `Gender`       int          NOT NULL,
    `DateCreated`  datetime(6)  NOT NULL,
    `DateModified` datetime(6)  NOT NULL,
    `CreatedBy`    varchar(256) NULL,
    `UpdatedBy`    varchar(256) NULL,
    `UpdatedDate`  datetime(6)  NOT NULL,
    `CreatedDate`  datetime(6)  NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `AppProductCategories`
(
    `Id`           int          NOT NULL AUTO_INCREMENT,
    `Name`         varchar(100) NOT NULL,
    `Description`  varchar(500) NULL,
    `Icon`         longtext     NULL,
    `DateCreated`  datetime(6)  NOT NULL,
    `DateModified` datetime(6)  NOT NULL,
    `CreatedBy`    varchar(256) NULL,
    `UpdatedBy`    varchar(256) NULL,
    `UpdatedDate`  datetime(6)  NOT NULL,
    `CreatedDate`  datetime(6)  NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `AspNetRoles`
(
    `Id`               varchar(255) NOT NULL,
    `Description`      longtext     NULL,
    `CreatedBy`        longtext     NULL,
    `UpdatedBy`        longtext     NULL,
    `CreatedDate`      datetime(6)  NOT NULL,
    `UpdatedDate`      datetime(6)  NOT NULL,
    `Name`             varchar(256) NULL,
    `NormalizedName`   varchar(256) NULL,
    `ConcurrencyStamp` longtext     NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `AspNetUsers`
(
    `Id`                   varchar(255) NOT NULL,
    `JobTitle`             longtext     NULL,
    `FullName`             longtext     NULL,
    `Configuration`        longtext     NULL,
    `IsEnabled`            tinyint(1)   NOT NULL,
    `CreatedBy`            longtext     NULL,
    `UpdatedBy`            longtext     NULL,
    `CreatedDate`          datetime(6)  NOT NULL,
    `UpdatedDate`          datetime(6)  NOT NULL,
    `UserName`             varchar(256) NULL,
    `NormalizedUserName`   varchar(256) NULL,
    `Email`                varchar(256) NULL,
    `NormalizedEmail`      varchar(256) NULL,
    `EmailConfirmed`       tinyint(1)   NOT NULL,
    `PasswordHash`         longtext     NULL,
    `SecurityStamp`        longtext     NULL,
    `ConcurrencyStamp`     longtext     NULL,
    `PhoneNumber`          longtext     NULL,
    `PhoneNumberConfirmed` tinyint(1)   NOT NULL,
    `TwoFactorEnabled`     tinyint(1)   NOT NULL,
    `LockoutEnd`           datetime(6)  NULL,
    `LockoutEnabled`       tinyint(1)   NOT NULL,
    `AccessFailedCount`    int          NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `OpenIddictApplications`
(
    `Id`                     varchar(255) NOT NULL,
    `ClientId`               varchar(100) NULL,
    `ClientSecret`           longtext     NULL,
    `ConcurrencyToken`       varchar(50)  NULL,
    `ConsentType`            varchar(50)  NULL,
    `DisplayName`            longtext     NULL,
    `DisplayNames`           longtext     NULL,
    `Permissions`            longtext     NULL,
    `PostLogoutRedirectUris` longtext     NULL,
    `Properties`             longtext     NULL,
    `RedirectUris`           longtext     NULL,
    `Requirements`           longtext     NULL,
    `Type`                   varchar(50)  NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `OpenIddictScopes`
(
    `Id`               varchar(255) NOT NULL,
    `ConcurrencyToken` varchar(50)  NULL,
    `Description`      longtext     NULL,
    `Descriptions`     longtext     NULL,
    `DisplayName`      longtext     NULL,
    `DisplayNames`     longtext     NULL,
    `Name`             varchar(200) NULL,
    `Properties`       longtext     NULL,
    `Resources`        longtext     NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `AppProducts`
(
    `Id`                int            NOT NULL AUTO_INCREMENT,
    `Name`              varchar(100)   NOT NULL,
    `Description`       varchar(500)   NULL,
    `Icon`              varchar(256)   NULL,
    `BuyingPrice`       decimal(18, 2) NOT NULL,
    `SellingPrice`      decimal(18, 2) NOT NULL,
    `UnitsInStock`      int            NOT NULL,
    `IsActive`          tinyint(1)     NOT NULL,
    `IsDiscontinued`    tinyint(1)     NOT NULL,
    `DateCreated`       datetime(6)    NOT NULL,
    `DateModified`      datetime(6)    NOT NULL,
    `ParentId`          int            NULL,
    `ProductCategoryId` int            NOT NULL,
    `CreatedBy`         varchar(256)   NULL,
    `UpdatedBy`         varchar(256)   NULL,
    `UpdatedDate`       datetime(6)    NOT NULL,
    `CreatedDate`       datetime(6)    NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AppProducts_AppProductCategories_ProductCategoryId` FOREIGN KEY (`ProductCategoryId`) REFERENCES `AppProductCategories` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AppProducts_AppProducts_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `AppProducts` (`Id`) ON DELETE RESTRICT
);


CREATE TABLE `AspNetRoleClaims`
(
    `Id`         int          NOT NULL AUTO_INCREMENT,
    `RoleId`     varchar(255) NOT NULL,
    `ClaimType`  longtext     NULL,
    `ClaimValue` longtext     NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AppOrders`
(
    `Id`           int            NOT NULL AUTO_INCREMENT,
    `Discount`     decimal(18, 2) NOT NULL,
    `Comments`     varchar(500)   NULL,
    `DateCreated`  datetime(6)    NOT NULL,
    `DateModified` datetime(6)    NOT NULL,
    `CashierId`    varchar(255)   NULL,
    `CustomerId`   int            NOT NULL,
    `CreatedBy`    varchar(256)   NULL,
    `UpdatedBy`    varchar(256)   NULL,
    `UpdatedDate`  datetime(6)    NOT NULL,
    `CreatedDate`  datetime(6)    NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AppOrders_AppCustomers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `AppCustomers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AppOrders_AspNetUsers_CashierId` FOREIGN KEY (`CashierId`) REFERENCES `AspNetUsers` (`Id`)
);


CREATE TABLE `AspNetUserClaims`
(
    `Id`         int          NOT NULL AUTO_INCREMENT,
    `UserId`     varchar(255) NOT NULL,
    `ClaimType`  longtext     NULL,
    `ClaimValue` longtext     NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AspNetUserLogins`
(
    `LoginProvider`       varchar(255) NOT NULL,
    `ProviderKey`         varchar(255) NOT NULL,
    `ProviderDisplayName` longtext     NULL,
    `UserId`              varchar(255) NOT NULL,
    PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AspNetUserRoles`
(
    `UserId` varchar(255) NOT NULL,
    `RoleId` varchar(255) NOT NULL,
    PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AspNetUserTokens`
(
    `UserId`        varchar(255) NOT NULL,
    `LoginProvider` varchar(255) NOT NULL,
    `Name`          varchar(255) NOT NULL,
    `Value`         longtext     NULL,
    PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `OpenIddictAuthorizations`
(
    `Id`               varchar(255) NOT NULL,
    `ApplicationId`    varchar(255) NULL,
    `ConcurrencyToken` varchar(50)  NULL,
    `CreationDate`     datetime(6)  NULL,
    `Properties`       longtext     NULL,
    `Scopes`           longtext     NULL,
    `Status`           varchar(50)  NULL,
    `Subject`          varchar(400) NULL,
    `Type`             varchar(50)  NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `OpenIddictApplications` (`Id`)
);


CREATE TABLE `AppOrderDetails`
(
    `Id`          int            NOT NULL AUTO_INCREMENT,
    `UnitPrice`   decimal(18, 2) NOT NULL,
    `Quantity`    int            NOT NULL,
    `Discount`    decimal(18, 2) NOT NULL,
    `ProductId`   int            NOT NULL,
    `OrderId`     int            NOT NULL,
    `CreatedBy`   varchar(256)   NULL,
    `UpdatedBy`   varchar(256)   NULL,
    `UpdatedDate` datetime(6)    NOT NULL,
    `CreatedDate` datetime(6)    NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AppOrderDetails_AppOrders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `AppOrders` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AppOrderDetails_AppProducts_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `AppProducts` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `OpenIddictTokens`
(
    `Id`               varchar(255) NOT NULL,
    `ApplicationId`    varchar(255) NULL,
    `AuthorizationId`  varchar(255) NULL,
    `ConcurrencyToken` varchar(50)  NULL,
    `CreationDate`     datetime(6)  NULL,
    `ExpirationDate`   datetime(6)  NULL,
    `Payload`          longtext     NULL,
    `Properties`       longtext     NULL,
    `RedemptionDate`   datetime(6)  NULL,
    `ReferenceId`      varchar(100) NULL,
    `Status`           varchar(50)  NULL,
    `Subject`          varchar(400) NULL,
    `Type`             varchar(50)  NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_OpenIddictTokens_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `OpenIddictApplications` (`Id`),
    CONSTRAINT `FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId` FOREIGN KEY (`AuthorizationId`) REFERENCES `OpenIddictAuthorizations` (`Id`)
);


CREATE INDEX `IX_AppCustomers_Name` ON `AppCustomers` (`Name`);


CREATE INDEX `IX_AppOrderDetails_OrderId` ON `AppOrderDetails` (`OrderId`);


CREATE INDEX `IX_AppOrderDetails_ProductId` ON `AppOrderDetails` (`ProductId`);


CREATE INDEX `IX_AppOrders_CashierId` ON `AppOrders` (`CashierId`);


CREATE INDEX `IX_AppOrders_CustomerId` ON `AppOrders` (`CustomerId`);


CREATE INDEX `IX_AppProducts_Name` ON `AppProducts` (`Name`);


CREATE INDEX `IX_AppProducts_ParentId` ON `AppProducts` (`ParentId`);


CREATE INDEX `IX_AppProducts_ProductCategoryId` ON `AppProducts` (`ProductCategoryId`);


CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);


CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);


CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);


CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);


CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);


CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);


CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);


CREATE UNIQUE INDEX `IX_OpenIddictApplications_ClientId` ON `OpenIddictApplications` (`ClientId`);


CREATE INDEX `IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type` ON `OpenIddictAuthorizations` (`ApplicationId`, `Status`, `Subject`, `Type`);


CREATE UNIQUE INDEX `IX_OpenIddictScopes_Name` ON `OpenIddictScopes` (`Name`);


CREATE INDEX `IX_OpenIddictTokens_ApplicationId_Status_Subject_Type` ON `OpenIddictTokens` (`ApplicationId`, `Status`, `Subject`, `Type`);


CREATE INDEX `IX_OpenIddictTokens_AuthorizationId` ON `OpenIddictTokens` (`AuthorizationId`);


CREATE UNIQUE INDEX `IX_OpenIddictTokens_ReferenceId` ON `OpenIddictTokens` (`ReferenceId`);


