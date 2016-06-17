using System;

namespace MapHive.Identity.MembershipReboot
{
    /// <summary>
    /// Pretty much the same as CustomConfig but with nullable types so can configure only the bits and pieces that are about to not be standard, with the rest defaulting to whatever they need to default
    /// </summary>
    public class NullableMembershipRebootConfiguration
    {
        public TimeSpan? AccountLockoutDuration { get; set; }
        public int? AccountLockoutFailedLoginAttempts { get; set; }
        public bool? AllowAccountDeletion { get; set; }
        public bool? AllowLoginAfterAccountCreation { get; set; }
        public string DefaultTenant { get; set; }
        public bool? EmailIsUnique { get; set; }
        public bool? EmailIsUsername { get; set; }
        public bool? MultiTenant { get; set; }
        public int? PasswordHashingIterationCount { get; set; }
        public int? PasswordResetFrequency { get; set; }
        public bool? RequireAccountVerification { get; set; }
        public bool? UsernamesUniqueAcrossTenants { get; set; }
        public TimeSpan? VerificationKeyLifetime { get; set; }
    }
}