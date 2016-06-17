using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot;
using Newtonsoft.Json;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomConfig : MembershipRebootConfiguration<CustomUserAccount>
    {
        private static readonly CustomConfig config;

        static CustomConfig()
        {
            //Basically json representation of the config should be same as this class. The main difference is the nullability of types,
            //so cfg does not have to provide all the properties but the ones that need customisation.

            NullableMembershipRebootConfiguration mbrCfg = null;
            try
            {
                mbrCfg = JsonConvert.DeserializeObject<NullableMembershipRebootConfiguration>(
                    ConfigurationManager.AppSettings["MembershipRebootConfiguration"]);
            }
            catch (Exception)
            {
                //ignore
            }

            config = new CustomConfig();

            if (mbrCfg != null)
            {
                config.AccountLockoutDuration = mbrCfg.AccountLockoutDuration ?? config.AccountLockoutDuration;
                config.AccountLockoutFailedLoginAttempts = mbrCfg.AccountLockoutFailedLoginAttempts ?? config.AccountLockoutFailedLoginAttempts;
                config.AllowAccountDeletion = mbrCfg.AllowAccountDeletion ?? config.AllowAccountDeletion;
                config.AllowLoginAfterAccountCreation = mbrCfg.AllowLoginAfterAccountCreation ?? config.AllowLoginAfterAccountCreation;
                config.DefaultTenant = mbrCfg.DefaultTenant ?? config.DefaultTenant;
                config.EmailIsUnique = mbrCfg.EmailIsUnique ?? config.EmailIsUnique;
                config.EmailIsUsername = mbrCfg.EmailIsUsername ?? config.EmailIsUsername;
                config.MultiTenant = mbrCfg.MultiTenant ?? config.MultiTenant;

                //0 or less means this will be worked out dynamically by MR
                config.PasswordHashingIterationCount = mbrCfg.PasswordHashingIterationCount ?? config.PasswordHashingIterationCount;
                config.PasswordResetFrequency = mbrCfg.PasswordResetFrequency ?? config.PasswordResetFrequency;
                config.RequireAccountVerification = mbrCfg.RequireAccountVerification ?? config.RequireAccountVerification;
                config.UsernamesUniqueAcrossTenants = mbrCfg.UsernamesUniqueAcrossTenants ?? config.UsernamesUniqueAcrossTenants;
                config.VerificationKeyLifetime = mbrCfg.VerificationKeyLifetime ?? config.VerificationKeyLifetime;
            }

            //example of adding  some evt listeners to MR config
            //config.AddEventHandler(new CustomEventHandler());
        }

        public static CustomConfig Get()
        {
            return config;
        }
    }
}
