// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("apibook", "ASP.NET Core Book API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "clientbook",

                    // 没有交互式用户，使用ClientId/ClientSecrets进行身份验证
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // 认证ClientId/ClientSecrets
                    ClientSecrets = {new Secret("secretbook".Sha256())},

                    // 客户端有权访问的范围
                    AllowedScopes = {"apibook"}
                }
            };

        public static IEnumerable<ApiResource> ApiResources => new[] {new ApiResource("apibook", "ASP.NET Core Book API")};
    }
}