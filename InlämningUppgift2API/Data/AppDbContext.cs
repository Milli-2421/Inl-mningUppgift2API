using InlämningUppgift2API.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace InlämningUppgift2API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder creating)
    {
            creating.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(creating);
     }

  }

}
     
