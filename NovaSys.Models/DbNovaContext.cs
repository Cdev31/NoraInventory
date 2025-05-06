using Microsoft.EntityFrameworkCore;
namespace prueba_tec.NovaSys.Models
{
    public class DbNovaContext : DbContext
    {
        public DbNovaContext(DbContextOptions<DbNovaContext> options) : base(options) { }
        public DbSet<ProductModel> ProductEN { get; set; }
        public DbSet<ClientModel> ClientEN { get; set; }
        public DbSet<OrderModel> OrderEN { get; set; }
        public DbSet<ProductOrderModel> ProductOrderEN { get; set; }

        public DbSet<StatesModel> StateEN { get; set; }
    }
}