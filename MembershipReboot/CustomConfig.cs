using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomConfig : MembershipRebootConfiguration<CustomUserAccount>
    {
        protected static readonly CustomConfig config;

        static CustomConfig()
        {
            config = new CustomConfig
            {
                EmailIsUnique = true,
                EmailIsUsername = true,

                //IdentityServer / MembershipReboot will not let user in without verification;
                RequireAccountVerification = true,

                MultiTenant = false
            };
            //example of adding  some evt listeners to MR config
            //config.AddEventHandler(new CustomEventHandler());
        }

        public static CustomConfig Get()
        {
            return config;
        }
    }
}
