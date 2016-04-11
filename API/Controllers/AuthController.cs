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

            var client = new TokenClient(
               $"{idSrvTokenClientOpts["Authority"]}/connect/token",
               idSrvTokenClientOpts["ClientId"],
               idSrvTokenClientOpts["ClientSecret"]);

            var result = await client.RequestResourceOwnerPasswordAsync(username, pass, idSrvTokenClientOpts["RequiredScopes"]);

            return result.AccessToken;
        }

    }
}
