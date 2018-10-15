// Copyright(c) Brock Allen & Dominick Baier.All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerWithAspNetIdentity
{
    public class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("demo1", "Demo Api Service"),
                // TODO: new ApiResource("xxx", "xxx Api Service")
            };
        }

        // Identity resources are data like user ID, name, or email address of a user
        // see: http://docs.identityserver.io/en/release/configuration/resources.html
        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>
            {
                // JavaScript Client
                //new Client
                //{
                //    ClientId = "js",
                //    ClientName = "eShop SPA OpenId Client",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AllowAccessTokensViaBrowser = true,
                //    RedirectUris =           { $"{clientsUrl["Spa"]}/" },
                //    RequireConsent = false,
                //    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                //    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "demoapi"//,
                //        //TODO: "xxx"
                //    }
                //},
                //new Client
                //{
                //    ClientId = "xamarin",
                //    ClientName = "eShop Xamarin OpenId Client",
                //    AllowedGrantTypes = GrantTypes.Hybrid,                    
                //    //Used to retrieve the access token on the back channel.
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    RedirectUris = { clientsUrl["Xamarin"] },
                //    RequireConsent = false,
                //    RequirePkce = true,
                //    PostLogoutRedirectUris = { $"{clientsUrl["Xamarin"]}/Account/Redirecting" },
                //    AllowedCorsOrigins = { "http://eshopxamarin" },
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        IdentityServerConstants.StandardScopes.OfflineAccess,
                //        "demoapi" //,
                //        // TODO: "xxx"

                //    },
                //    //Allow requesting refresh tokens for long lived API access
                //    AllowOfflineAccess = true,
                //    AllowAccessTokensViaBrowser = true
                //},
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientUri = $"{clientsUrl["Mvc"]}",                             // public uri of the client
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //IdentityServerConstants.StandardScopes.OfflineAccess,
                        "demo1" //,
                        // TODO: "xxx"
                    },
                },
                new Client
                {
                    ClientId = "mvctest",
                    ClientName = "MVC Client Test",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientUri = $"{clientsUrl["Mvc"]}",                             // public uri of the client
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //IdentityServerConstants.StandardScopes.OfflineAccess,
                        "demo1" //,
                        // TODO: "xxx"
                    },
                },
                new Client
                {
                    ClientId = "demoapiswaggerui",
                    ClientName = "DemoApi Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["DemoApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["DemoApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "demo1"
                    }
                }//,
               //new Client
               // {
               //     ClientId = "xxx",
               //     ClientName = "xxx Swagger UI",
               //     AllowedGrantTypes = GrantTypes.Implicit,
               //     AllowAccessTokensViaBrowser = true,

               //     RedirectUris = { $"{clientsUrl["xxx"]}/swagger/o2c.html" },
               //     PostLogoutRedirectUris = { $"{clientsUrl["xxx"]}/swagger/" },

               //     AllowedScopes =
               //     {
               //         "xxx"
               //     }
               // }
            };
        }
    }
}