using Microsoft.EntityFrameworkCore;
using UsersDirectory.API.Entities;

namespace UsersDirectory.API
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UserDirectory");
        }
    }
}
