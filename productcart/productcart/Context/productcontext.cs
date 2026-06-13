using Microsoft.EntityFrameworkCore;
using productcart.Entity;

namespace productcart.Context
{
    public class productcontext : DbContext
    {        public productcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<order> Order { get; set; }
        public DbSet<product> Product { get; set; }
        public DbSet<user> User { get; set; }

    }
}
