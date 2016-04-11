using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MapHive.Identity.MembershipReboot;
using IdentityServer3.MembershipReboot;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class CustomMembershipRebootUserService : MembershipRebootUserService<CustomUserAccount>
    {
        public CustomMembershipRebootUserService(CustomUserAccountService userSvc)
            : base(userSvc)
        {
        }
    }
}