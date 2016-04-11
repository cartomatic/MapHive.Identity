using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot.Ef;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomUserAccountRepository : DbContextUserAccountRepository<CustomDbContext, CustomUserAccount>
    {
        public CustomUserAccountRepository(CustomDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
