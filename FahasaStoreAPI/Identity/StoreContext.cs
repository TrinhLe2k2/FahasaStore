using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FahasaStoreAPI.Identity
{
    public partial class StoreContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

    }
}
