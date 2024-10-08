using AccountAuditory.Data.Configurations;
using AccountAuditory.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountAuditory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<Buildings> Buildings { get; set;}
        public DbSet<Auditory> Auditoriums { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomItemConfiguration());

            modelBuilder.Entity<Auditory>(entity =>
            {
                entity.HasOne(a => a.Buildings) 
                    .WithMany()
                    .HasForeignKey(a => a.BuildingId);

                entity.HasOne(a => a.TypeRoom) 
                    .WithMany()
                    .HasForeignKey(a => a.TypeRoomId);
            });
        }

    }
}
