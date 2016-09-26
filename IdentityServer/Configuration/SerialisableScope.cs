using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace MapHive.Identity.IdentityServer.Configuration
{
    /// <summary>
    /// Provides a DTO object that is used to read the data off the web.config;
    /// This object is likely to evolve with time
    /// </summary>
    public class SerialisableScope
    {
        public SerialisableScope()
        {
        }

        /// <summary>
        /// Name of the scope. This is the value a client will use to request the scope.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name. This value will be used e.g. on the consent screen.
        /// </summary> 
        public string DisplayName { get; set; }

        /// <summary>
        /// Description. This value will be used e.g. on the consent screen.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Specifies whether this scope is about identity information from the userinfo endpoint, or a resource (e.g. a Web API). Defaults to Resource.
        /// </summary>   
        public ScopeType Type { get; set; }

        /// <summary>
        /// List of user claims that should be included in the identity (identity scope) or access token (resource scope).
        /// </summary>
        public List<ScopeClaim> Claims { get; set; }

        public Scope ToScope()
        {
            return new Scope
            {
                Name = Name,
                DisplayName = DisplayName,
                Description = Description,
                Type = Type,
                Claims = Claims
            };
        }

        ////
        //// Summary:
        ////     Specifies whether this scope is allowed to see other scopes when using the introspection
        ////     endpoint
        //public bool AllowUnrestrictedIntrospection { get; set; }
        
        ////
        //// Summary:
        ////     Rule for determining which claims should be included in the token (this is implementation
        ////     specific)
        //public string ClaimsRule { get; set; }
        
        
        ////
        //// Summary:
        ////     Specifies whether the consent screen will emphasize this scope. Use this setting
        ////     for sensitive or important scopes. Defaults to false.
        //public bool Emphasize { get; set; }
        ////
        //// Summary:
        ////     Indicates if scope is enabled and can be requested. Defaults to true.
        //public bool Enabled { get; set; }
        ////
        //// Summary:
        ////     If enabled, all claims for the user will be included in the token. Defaults to
        ////     false.
        //public bool IncludeAllClaimsForUser { get; set; }
        
        ////
        //// Summary:
        ////     Specifies whether the user can de-select the scope on the consent screen. Defaults
        ////     to false.
        //public bool Required { get; set; }
        ////
        //// Summary:
        ////     Gets or sets the scope secrets.
        //public List<Secret> ScopeSecrets { get; set; }
        ////
        //// Summary:
        ////     Specifies whether this scope is shown in the discovery document. Defaults to
        ////     true.
        //public bool ShowInDiscoveryDocument { get; set; }
        //
       
    }
}