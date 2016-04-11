using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot;

namespace MapHive.Identity.MembershipReboot
{
    //Note:
    //More events here:
    //https://github.com/brockallen/BrockAllen.MembershipReboot/blob/master/src/BrockAllen.MembershipReboot/AccountService/UserAccountEvents.cs
    //combine this with the email templates to see what happens when and what kind of information is available
    //
    //istead of handling the events 'manually' one can use the email notificaion events that wrap the user account events
    //and provide email sending facilities (through own handlers of course)
    //in such case though, the email configuration is sucked in from the web.configs predefined location, so it is not possible to make it dynamic;
    //while in most cases this will be just fine, sometimes there may be a need to send a customised msg based on the callee, etc.
    //https://github.com/brockallen/BrockAllen.MembershipReboot/blob/793613303c08463bcb88177df3eb6e35d1253591/src/BrockAllen.MembershipReboot/Notification/Email/EmailNotificationEventHandlers.cs

    //Note: events are added to the MR config object!
    public class CustomEventHandler : IEventHandler<BrockAllen.MembershipReboot.SuccessfulLoginEvent<CustomUserAccount>>
    {
        public void Handle(SuccessfulLoginEvent<CustomUserAccount> evt)
        {
            //can do custom processing here...

            var stop = false;
        }
    }
}
