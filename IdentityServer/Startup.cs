using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Configuration;
using IdentityManager.Configuration;
using IdentityServer3.Core.Configuration;
using MapHive.Identity.IdentityServer.Configuration;


namespace MapHive.Identity.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //grab the conn names for the MR and IdSrv databases
            var mrDbConnStringName = ConfigurationManager.AppSettings["MembershipRebootDb"];
            var idSrvDbConnStringName = ConfigurationManager.AppSettings["IdentityServerDb"];


            //expose identity manager at /admin
            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.Configure(mrDbConnStringName);

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory
                });
            });


            //expose identity server at /core
            app.Map("/core", core =>
            {
                var idSvrFactory = Factory.Configure(idSrvDbConnStringName);

                idSvrFactory.ConfigureCustomUserService(mrDbConnStringName);

                var options = new IdentityServerOptions
                {
                    SiteName = "MapHive IdentityServer",

                    IssuerUri = ConfigurationManager.AppSettings["IdentityServerUri"],

                    //If the IdSrv is behind a firewall, load balancer, webgarden, it needs to know what is its public uri
                    PublicOrigin = ConfigurationManager.AppSettings["IdentityServerOrigin"], 

                    SigningCertificate = Certificate.Get(),

                    Factory = idSvrFactory
                };

                core.UseIdentityServer(options);
            });
        }
    }
}