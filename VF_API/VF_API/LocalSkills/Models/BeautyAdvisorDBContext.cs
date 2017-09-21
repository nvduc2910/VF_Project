using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class LocalSkillDBContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public LocalSkillDBContext(DbContextOptions<LocalSkillDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("User");

            });
            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRole");
            });
            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogin");
            });
            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaim");
            });
            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserToken");
            });
            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaim");
            });
        }

        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductRemainder> ProductRemainder { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductSchedule> ProductSchedule { get; set; }

        public virtual DbSet<ReviewProduct> ReviewProduct { get; set; }
        public virtual DbSet<FavoriteProduct> FavoritesProduct { get; set; }

        public virtual DbSet<ProductAttender> ProductAttender { get; set; }

        public virtual DbSet<Message> Message { get; set; }

        public virtual DbSet<Converstation> Converstation { get; set; }
    }
}
