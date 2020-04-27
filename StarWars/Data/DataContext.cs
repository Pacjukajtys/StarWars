using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarWars.Models;

namespace StarWars.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostEpisode>().Ignore(xx => xx.Post).HasKey(x => new { x.PostId, x.EpisodeName });
            modelBuilder.Entity<PostFriend>().Ignore(yy => yy.Post).HasKey(x => new { x.PostId, x.FriendName });
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostEpisode> PostEpisode { get; set; }
        public DbSet<PostFriend> PostFriend { get; set; }
    }
}
