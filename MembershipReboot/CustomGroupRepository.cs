using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot.Ef;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomGroupRepository : DbContextGroupRepository<CustomDbContext, CustomGroup>
    {
        public CustomGroupRepository(CustomDbContext ctx)
            : base(ctx)
        {
        }
    }
}
