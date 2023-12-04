using Microsoft.EntityFrameworkCore;
using TrackMoney.Data.Models.Entities;

namespace TrackMoney.Data
{
    public class TrackMoneyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Сurrency> Currencies { get; set; }

        public TrackMoneyDbContext(DbContextOptions<TrackMoneyDbContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
