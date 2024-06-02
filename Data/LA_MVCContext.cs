using Microsoft.EntityFrameworkCore;

namespace LeonardoAndradeBackendMVC.Data
{
    public class LA_MVCContext :DbContext
    {
        public LA_MVCContext(DbContextOptions<LA_MVCContext> options):
            base(options)
        { 
        }

        public DbSet<LeonardoAndradeBackendMVC.Models.LA_Burger> LA_Burger { get; set; } = default!;
        public DbSet<LeonardoAndradeBackendMVC.Models.LA_Promo> LA_Promo { get; set; } = default!;
    }
}
