using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomGroup : RelationalGroup
    {
        //customise if needed. but in general groups will not be used. they are needed, so can plug in Identity manager that needs this bit
        //when customising, make the extra properties virtual
    }
}
