using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrockAllen.MembershipReboot;
using MapHive.Identity.MembershipReboot;
using IdentityManager.MembershipReboot;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.MembershipReboot;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class CustomMembershipRebootIdentityManagerService : MembershipRebootIdentityManagerService<CustomUserAccount, CustomGroup>
    {
        public CustomMembershipRebootIdentityManagerService(CustomUserAccountService userSvc, CustomGroupService groupSvc)
            : base(userSvc, groupSvc)
        {
        }
    }
}