using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using Owin;
using IdentityServer3.AccessTokenValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MapHive.Identity.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var idSrvBearerTokenAuthOpts = JsonConvert.DeserializeObject<Dictionary<string, string>>(ConfigurationManager.AppSettings["IdSrvBearerTokenAuthOpts"]);

            // Wire token validation  - comes from Identity3.AccessTokenValidation
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                //wherever the IdSrv is...
                Authority = idSrvBearerTokenAuthOpts["Authority"],

                //adding clientId, secret (scope based!!!!) makes the middleware use the introspection endpoint instead of
                //the validation endpoint

                //For access to the introspection endpoint
                //ClientId = idSrvBearerTokenAuthOpts["ClientId"], //In IdentityServer this is a name of an authorised scope

                //In IdentityServer this is a secret associated with a scope
                //ClientSecret = idSrvBearerTokenAuthOpts["ClientSecret"],

                //scopes that are required - client also needs to have them configured as allowed scopes
                //and also an access token needs to be requested asking specifically for that scope.
                //only if the scope is present in the JWT scope arr, the bearer token auth will allow pass through.
                //only one of the scopes is required - token does not have to have all of them
                RequiredScopes = !string.IsNullOrWhiteSpace(idSrvBearerTokenAuthOpts["RequiredScopes"]) ?
                                idSrvBearerTokenAuthOpts["RequiredScopes"].Split(' ')
                                :
                                new string[0],

                //enable caching the validation results
                EnableValidationResultCache = true,
                //time the cache is valid - during that time the authentication mechanism will not contact IdSrv to validate the token
                ValidationResultCacheDuration = new TimeSpan(0,0,0,10) //make the cache valid for 10 seconds

            });


            //TODO - ??? Maybe move the WebAPI cfg to an external class / method as it is done in the actual WebAPI templates ???

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            //newtosoft json formatting! so nicely indented json is returned
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented; 

            //make the json props be camel case!
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //add authorise attribute to all requests
            //httpConfiguration.Filters.Add(new AuthorizeAttribute());


            app.UseWebApi(config);
        }
    }
}