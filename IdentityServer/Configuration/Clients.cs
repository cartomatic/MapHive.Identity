using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                //TODO - move the clients to some other persistent storage- db, maybe web.config (will cause app pool reload) or a txt / json file, so no need to recompile when this changes - during the dev though this is not that bad

                //client that will authenticate user and obtain token in his name;
                //because the auth is proxied, SSO will not work
                //this client accesses the IdentityServer from the IdentityAPI level and obtains a token that is later used to access the rekayted APIs
                new Client
                {
                    ClientName = "MapHive API",
                    ClientId = "maphive-api",
                    Enabled = true,

                    //Note: because JWT token carries quite a lot of potentially sensitive info, use the reference token
                    //reference tokens are good, whenever data leaves safe machine-to-machine realms and is send to public facing sites
                    //this means, there s a need for a peristent storage, so the tokens can be shared amongst many IdSrv instances if required and also remain valid
                    //if IdSrv AppPool needs to recycle, or the app is set up as a WebGarden or behind a load balancer
                    AccessTokenType = AccessTokenType.Reference,
                    //AccessTokenType = AccessTokenType.Jwt, //nice, but very verbose and potentially carries sensitive data (if requested of course :)

                    //so can actually access it directly using a secret
                    Flow = Flows.ResourceOwner,

                    //TODO - work out a sensible token lifetime; use refresh tokens to renew access tokens silently
                    //TODO - or use token cache in the web api and wipe out tokens in the db if not needed anymore.
                    //Therefore maybe instead of playing with the token lifetime, cache lifetime is used when configuring UseIdentityServerBearerTokenAuthentication
                    //check EnableValidationResultCache and ValidationResultCacheDuration of the IdentityServerBearerTokenAuthenticationOptions.
                    //AccessTokenLifetime = 70,



                    ClientSecrets = new List<Secret>
                    {
                        new Secret("maphive-api-test-secret".Sha256()) //validated when obtaining a token
                    },

                    //allow access to the identity-api and maphive-api endpoints
                    AllowedScopes = new List<string>
                    {
                        "maphive_api",
                        Constants.StandardScopes.OfflineAccess

                        //no need for identity scopes here. will use resource owner flow
                    }
                }

                //Note:
                //If external auth is to be added, a new client with the implicit flow will be required
            };
        }
    }
}