using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MapHive.Identity.API.Controllers
{
    public class TestController : ApiController
    {
        /// <summary>
        /// No auth access test
        /// </summary>
        /// <returns></returns>
        [Route("test/noauth")]
        [HttpGet]
        public string AllowNonAuthorised()
        {
            return "Non-authorised access allowed";
        }

        /// <summary>
        /// auth access test
        /// </summary>
        /// <returns></returns>
        [Route("test/auth")]
        [HttpGet]
        [Authorize]
        public string PreventNonAuthorised()
        {
            //current user of the api
            var claimsPrincipal = User as ClaimsPrincipal;

            //can now search claims and extract the data needed to get the roles and such...

            return "Only authorised access allowed";
        }
    }
}
