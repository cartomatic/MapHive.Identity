using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomUserAccountService : UserAccountService<CustomUserAccount>
    {
        public CustomUserAccountService(CustomConfig config, CustomUserAccountRepository repo)
            : base(config, repo)
        {
        }
    }
}
