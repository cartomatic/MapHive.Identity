using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using Newtonsoft.Json;

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
            //some base scopes that are always included.            
            var baseScopes = new List<Scope>
            {
                
                //For the initial setup no identity scopes are defined as at this stage neither implicit flow nor SSO are required 
                //claims data is accessed through the particular scopes!
                
                //the only exception is the offline_access scope, so the refresh tokens can be obtained
                StandardScopes.OfflineAccess,

                //standard identity scopes - will not be included when requesting access token - see claims description below
                //the only exception is the openid - this will be included as sub (subject / user ID)
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email
                //Note: Identity scopes also define scope claims, the actual claims that should be included in the scope
            };


            //read scopes off the web.config
            var extraScopes = new List<Scope>();

            try
            {
                //read the other scopes off the webconfig...
                extraScopes =
                    JsonConvert.DeserializeObject<List<SerialisableScope>>(
                        ConfigurationManager.AppSettings["IdentityServerScopes"])
                        .Select(s => s.ToScope()).ToList();

                //an example of a scope definition:
                //all moved to web.config for now

                //new Scope
                //{
                //    Name = "maphive_api",

                //    DisplayName = "MapHive API",
                //    Description = "Grants access to the MapHive API",

                //  Type = ScopeType.Resource,


                //    //secret is needed so can use it for the access token validation at the service level
                //    //when using introspection endpoint! Did not manage to make it work to well though, so using the resource owner flow with the client credentials
                //    //ScopeSecrets = new List<Secret>
                //    //{
                //    //    new Secret("maphive-api-scope-test-secret".Sha256())
                //    //},

                //    //controls the claims the scope has access to.
                //    //when authenticating and obtaining an access token, this is the way of including the extra claims in the scope by default
                //    Claims = new List<ScopeClaim>
                //    {
                //        //specify the user claims the scope exposes
                //        //stuff like emails, etc. see the IdSrv metadata endpoint to see what claims / scopes are supported
                //        new ScopeClaim(StandardScopes.OpenId.Name, alwaysInclude: true),


                //        //TODO - put here whatever the claims are needed later on; although it is likely that the only thing needed initially will be the subject / openid
                //        //new ScopeClaim(StandardScopes.Profile.Name, alwaysInclude: true),
                //        //new ScopeClaim("name", alwaysInclude: true),
                //        //new ScopeClaim("given_name", alwaysInclude: true),
                //        //new ScopeClaim("family_name", alwaysInclude: true),
                //        //new ScopeClaim("email", alwaysInclude: true),
                //        //new ScopeClaim("role", alwaysInclude: true),
                //        //new ScopeClaim("website", alwaysInclude: true),
                //        //more standard claims are available through the server metadata endpoint

                //        //custom claim - as long as this claim will be present on the user it will get returned
                //        //this is a custom identity claim

                //        //new ScopeClaim("custom_claim", alwaysInclude: true),
                //    }
                //}
            }
            catch (Exception ex)
            {
                //ignore
                //TODO - plug in a logger of some sort... the best option - a logger with api, so can store all the mess in the db and provide a sensible UI to review it...
            }

            //merge the data
            baseScopes.AddRange(extraScopes);

            return baseScopes;
        }
    }
}