using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class Scopes
    {
        /// <summary>
        /// Returns a list of scopes that a client can ask for when authenticating a user
        /// </summary>
        /// <returns></returns>
        public static List<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                //StandardScopes.Profile,

                StandardScopes.Email,
                //Note, when requesting access token, the above gets discarderd,
                //can use istead
                StandardScopes.ProfileAlwaysInclude,

                new Scope
                {
                    Name = "identity-api",

                    DisplayName = "Identity API",
                    Description = "Grants access to the Identity API - authentication and user handling endpoint",

                    //secret is needed so can use it for the access token validation at the service level
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("identity-api-scope-test-secret".Sha256())
                    },

                    Type = ScopeType.Resource
                },

                new Scope
                {
                    Name = "maphive-api",

                    DisplayName = "MapHiveAPI",
                    Description = "Grants access to the MapHiveAPI",

                    //secret is needed so can use it for the access token validation at the service level
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("maphive-api-scope-test-secret".Sha256())
                    },

                    Type = ScopeType.Resource
                }
            };
        }
    }
}