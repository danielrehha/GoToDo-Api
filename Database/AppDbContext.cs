using gotodo_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gotodo_api.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<User> users { get; set; }
        public DbSet<TodoItem> todoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<TodoItem>().HasKey(i => i.Id);
            builder.Entity<TodoItem>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().HasKey(u => u.UserId);
            //builder.Entity<TodoItem>().HasOne<User>().WithMany<TodoItem>(t => t.UserId);
            //builder.Entity<TodoItem>().HasOne<User>(u => u.Id);

        }
    }
}