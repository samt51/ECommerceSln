// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using IdentityServer4;

namespace ECommerce.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog") { Scopes = { "catalog_fullpermission" } },
            new ApiResource("photo_stock_catalog") { Scopes = { "photoStock_fullpermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
              new IdentityResources.Email(),
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResource(){Name = "roles",DisplayName = "Roles",Description = "Kullanıcı Rolleri",UserClaims = new[]{"role"}}
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
              new ApiScope("catalog_fullpermission","Katalog Service için full erişim"),
              new ApiScope("photoStock_fullpermission","Fotoğraf Service için full erişim"),
              new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "Asp.Net.Core Mvc",
                    ClientId = "WebMvcClient",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "catalog_fullpermission", "photoStock_fullpermission", IdentityServerConstants.LocalApi.ScopeName }


                },

                new Client
                {
                ClientName = "Asp.Net.Core Mvc",
                ClientId = "WebMvcClientForUser",
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess,"roles"
                },AccessTokenLifetime = 1*60*60,
                RefreshTokenExpiration = TokenExpiration.Absolute,
                AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                RefreshTokenUsage = TokenUsage.ReUse


                }
            };
    }
}