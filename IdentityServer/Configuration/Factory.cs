using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class Factory
    {
        public static IdentityServerServiceFactory Configure()
        {
            var factory = new IdentityServerServiceFactory();

            //Note:
            //Users repository configured through the CustomUserServices class

            //In memory scopes and clients

            var scopeStore = new InMemoryScopeStore(Scopes.Get());
            factory.ScopeStore = new Registration<IScopeStore>(resolver => scopeStore);

            var clientStore = new InMemoryClientStore(Clients.Get());
            factory.ClientStore = new Registration<IClientStore>(resolver => clientStore);

            return factory;
        }
    }
}