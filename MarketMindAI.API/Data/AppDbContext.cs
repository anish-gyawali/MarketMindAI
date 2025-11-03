using Microsoft.EntityFrameworkCore;
using MarketMind.ML.Contracts.Models.Entities;

namespace MarketMind.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Stock> Stocks => Set<Stock>();
    }
}
