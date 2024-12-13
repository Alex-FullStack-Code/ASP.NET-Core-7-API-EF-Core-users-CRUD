using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCommunity>().HasKey(uc => new
            {
                uc.UserId,
                uc.CommunityId
            });

            modelBuilder.Entity<UserCommunity>().HasOne(u => u.User).WithMany(uc => uc.UserCommunities).HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<UserCommunity>().HasOne(c => c.Community).WithMany(uc => uc.UserCommunities).HasForeignKey(c => c.CommunityId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Username> Usernames { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<UserCommunity> UserCommunities { get; set; }
    }
}
