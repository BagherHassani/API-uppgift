using _02_API.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _02_API
{
    public class SqlContext:DbContext
    {
        public SqlContext()
        {
        }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }

        public virtual DbSet<AddressEntity> Adresses { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }

    }
}
