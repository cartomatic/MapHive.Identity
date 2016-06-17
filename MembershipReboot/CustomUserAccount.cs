using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot.Relational;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomUserAccount : RelationalUserAccount
    {
        //Note: all the extra properties should be virtual

        //Note: the actual user account datamodel of MapHive is kept in the maphive metadata db
        //MemebrshipReboot is only used as a Identity provider for IdentityServer
    }
}
