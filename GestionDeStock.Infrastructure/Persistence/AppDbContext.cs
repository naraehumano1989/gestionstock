using GestionDeStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionDeStock.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
