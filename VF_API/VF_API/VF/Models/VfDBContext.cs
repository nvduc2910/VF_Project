using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class VfDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public VfDbContext(DbContextOptions<VfDbContext> options) : base(options)
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

        public virtual DbSet<ScopeBusiness> ScopeBusiness { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileScopeBusiness> ProfileScopeBusiness { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Converstation> Converstation { get; set; }
        public virtual DbSet<FocusIndustry> FocusIndustry { get; set; }

        public virtual DbSet<CompanySize> CompanySize { get; set; }
        public virtual DbSet<CharterCapital> CharterCapital { get; set; }
        public virtual DbSet<Revenue> Revenue { get; set; }

        public virtual DbSet<ProductionCapacity> ProductionCapacity { get; set; }
        public virtual DbSet<Market> Market { get; set; }

        public virtual DbSet<ProfileFocusIndustry> ProfileFocusIndustry { get; set; }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<City> City { get; set; }
    }
}
