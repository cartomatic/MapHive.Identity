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
                //For the initial setup no identity scopes are defined as at this stage neither implicit flow nor SSO are required 
                //claims data is accessed through the particular scopes!

                //TODO - move the scopes to some other persistent storage- db, maybe web.config (will cause app pool reload) or a txt / json file, so no need to recompile when this changes - during the dev though this is not that bad
                

                new Scope
                {
                    Name = "identity-api",

                    DisplayName = "Identity API",
                    Description = "Grants access to the Identity API - authentication and user handling endpoint",

                    Type = ScopeType.Resource,

                    Claims = new List<ScopeClaim>
                    {
                        //specify the user claims the scope exposes

                    }
                },

                //Note: think this is gonna be the only scope for now.
                //the identity api will become a core identity api logics class lib that needs to be exposed through a webservice
                new Scope
                {
                    Name = "maphive_api",

                    DisplayName = "MapHiveAPI",
                    Description = "Grants access to the MapHiveAPI",

                    Type = ScopeType.Resource,

                    Claims = new List<ScopeClaim>
                    {
                        //specify the user claims the scope exposes
                        //stuff like emails, etc. see the IdSrv metadata endpoint to see what claims / scopes are supported
                    }
                }
            };
        }
    }
}