using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MapHive.Identity.MembershipReboot;
using IdentityManager;
using IdentityManager.Configuration;
using IdentityServer3.Core.Services;


namespace MapHive.Identity.IdentityServer.Configuration
{
    public static class IdentityManagerServiceFactoryExtensions
    {
        public static void Configure(this IdentityManagerServiceFactory factory, string connStringName)
        {
            factory.IdentityManagerService = new Registration<IIdentityManagerService, CustomMembershipRebootIdentityManagerService>();
            factory.Register(new Registration<CustomUserAccountService>());
            factory.Register(new Registration<CustomGroupService>());
            factory.Register(new Registration<CustomUserAccountRepository>());
            factory.Register(new Registration<CustomGroupRepository>());
            factory.Register(new Registration<CustomDbContext>(resolver => new CustomDbContext(connStringName)));
            factory.Register(new Registration<CustomConfig>(CustomConfig.Get()));
        }
    }
}