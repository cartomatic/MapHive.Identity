using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                //client that will authenticate user and obtain token in his name;
                //because the auth is proxied, SSO will not work
                //this client accesses the IdentityServer from the IdentityAPI level and obtains a token that is later used to access the rekayted APIs
                new Client
                {
                    ClientName = "MapHive API Client",
                    ClientId = "maphive-api-client",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,

                    //so can actually access it directly using a secret
                    Flow = Flows.ResourceOwner,

                    //TODO - work out a sensible lifetime for the access token!
                    //AccessTokenLifetime = 70,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("maphive-api-client-test-secret".Sha256()) //validated when obtaining a token
                    },

                    //allow access to the identityapi and webgisapi endpoints
                    AllowedScopes = new List<string> { "identity-api", "maphive-api" }
                }

                //Note:
                //If external auth is to be added, a new client with the implicit flow will be required
            };
        }
    }
}