using Domain.Entity.UrlManagement;
using Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<UrlItem> UrlItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<User>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            //Admin
            modelBuilder.Entity<Admin>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            //Lot
            modelBuilder.Entity<UrlItem>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Creator)
                .WithMany(b => b.UrlItems)
                .IsRequired(true)
                .HasForeignKey(k => k.CreatorId);
            });
        }
    }
}
