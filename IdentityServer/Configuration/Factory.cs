using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;
using IdentityServer3.EntityFramework;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class Factory
    {
        public static IdentityServerServiceFactory Configure(string idSrvConnStrName)
        {
            var factory = new IdentityServerServiceFactory();

            //Note:
            //Users repository configured through the CustomUserServices class

            //In memory scopes and clients

            var scopeStore = new InMemoryScopeStore(Scopes.Get());
            factory.ScopeStore = new Registration<IScopeStore>(resolver => scopeStore);

            var clientStore = new InMemoryClientStore(Clients.Get());
            factory.ClientStore = new Registration<IClientStore>(resolver => clientStore);

            //this will configure the opeartional services
            factory.RegisterOperationalServices(new EntityFrameworkServiceOptions
            {
                ConnectionString = idSrvConnStrName,
                Schema = MapHive.Identity.IdentityServer.Migrations.OperationalDbContext.Schema
            });

            //schemas for the clients and scopes storage as follows:
            //MapHive.Identity.IdentityServer.Migrations.ScopeConfigurationDbContext.Schema
            //MapHive.Identity.IdentityServer.Migrations.ClientConfigurationDbContext.Schema

            //Note: this would register a service for configurations - clients, scopes, users
            //need the seed methods for them too.
            //factory.RegisterConfigurationServices(efConfig);
            //or
            //RegisterScopeStore
            //RegisterClientStore

            return factory;
        }
    }
}