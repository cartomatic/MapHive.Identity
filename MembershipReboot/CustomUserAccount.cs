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


        //TODO - some MapHive related user properties

        //Note:
        //This can be also done as an extra user storage object or objects just need to extend the custom db context by adding the required db sets; then the user account handling needs to account for the xtra properties.
        //This is actually even better idea, as the MembershipReboot stuff is kep in one place only and the customisation gets its own table(s)
    }
}
