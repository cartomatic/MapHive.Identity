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

        /// <summary>
        /// Gets an instance of CustomUserAccountService bound to a particular db context
        /// </summary>
        /// <param name="connStringName"></param>
        /// <returns></returns>
        public static CustomUserAccountService GetInstance(string connStringName)
        {
            return GetInstance(new CustomDbContext(connStringName));
        }

        /// <summary>
        /// Gets an instance of CustomUserAccountService bound to a particular db context
        /// </summary>
        /// <typeparam name="TDbCtx"></typeparam>
        /// <param name="dbCtx"></param>
        /// <returns></returns>
        public static CustomUserAccountService GetInstance<TDbCtx>(TDbCtx dbCtx)
            where TDbCtx : CustomDbContext
        {
            return new CustomUserAccountService(
                CustomConfig.Get(),
                new CustomUserAccountRepository(dbCtx)
            );
        }
    }
}
