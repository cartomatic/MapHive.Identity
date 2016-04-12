using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace MapHive.Identity.API.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : ApiController
    {
        [Route("login")]
        [HttpGet]
        [HttpPost]
        public async Task<IHttpActionResult> LogIn(string email, string pass)
        {

            //TODO - first check user against membership reboot so can customise output


            //and if ok obtain a token
            var token = await GetToken(email, pass);

            return Ok(token);
        }


        /// <summary>
        /// Gets an authentication token for a particular user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        protected async Task<string> GetToken(string username, string pass)
        {
            var idSrvTokenClientOpts = JsonConvert.DeserializeObject<Dictionary<string, string>>(ConfigurationManager.AppSettings["IdSrvTokenClientOpts"]);

            //cfg here is for the client that will actually obtain the access token and claims defined in the requested scopes for given user credentials
            var client = new TokenClient(
               $"{idSrvTokenClientOpts["Authority"]}/connect/token",
               idSrvTokenClientOpts["ClientId"],
               idSrvTokenClientOpts["ClientSecret"]);

            var result = await client.RequestResourceOwnerPasswordAsync(username, pass, idSrvTokenClientOpts["RequiredScopes"]);

            //requierd scopes - get the access token for the scopes and whatever claims they expose. scopes are necessary for the scopeauthorisation at the api level (if used of course);
            //basically the bearer token auth cfg defines scopes that are required for the user / client to have in order to access the protected content
            //offline_access scope is required to obtain if the refresh token is to be reused
            //
            //when using reference tokens, no data is returned with the call but the access token (and the refresh token if required). It is the Bearer token auth that call the IdentityServer
            //on a scheduled basis in order to validate the reference token and obtain the actual scope data - an equivalent of the JWT token

            //???? - will we need refresh token too??? likely so; but skip it for the time being.
            //if 401 pops out on the client it will prompt for re-logon anyway

            return result.AccessToken;
        }

    }
}
