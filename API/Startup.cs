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
                Authority = idSrvBearerTokenAuthOpts["Authority"],

                // For access to the introspection endpoint
                ClientId = idSrvBearerTokenAuthOpts["ClientId"], //In IdentityServer this is a name of an authorised scope

                //In IdentityServer this is a secret associated with a scope
                ClientSecret = idSrvBearerTokenAuthOpts["ClientSecret"], 

                //the client for whom a token is generated requires access to the following scopes in order to use the IdentityAPI
                RequiredScopes = idSrvBearerTokenAuthOpts["RequiredScopes"].Split(',')
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