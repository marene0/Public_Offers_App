using PublicOffer.Model;
using Microsoft.EntityFrameworkCore;
namespace PublicOffer.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<UserOffer> UserOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                  .HasMany(m => m.UserOffers)
                  .WithOne(m => m.User)
                 .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<Offer>()
                  .HasMany(m => m.UserOffers)
                  .WithOne(m => m.Offer);

            modelBuilder.Entity<UserOffer>()
                   .HasKey(e => new { e.UserId, e.OfferId });
        }
    }
}
