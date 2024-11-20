using CardsServerD100923ER.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsServerD100923ER.Infrastructure.Data
{
    public class CardsProjectDbContext :DbContext
    {
       public DbSet<User> Users {  get; set; }
       public DbSet<Card> Cards {  get; set; }

        public CardsProjectDbContext(DbContextOptions<CardsProjectDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasMany<User>()
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "Likes",
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.HasOne<Card>().WithMany().HasForeignKey("CardId"));
        }

    }
}
