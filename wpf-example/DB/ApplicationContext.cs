using Microsoft.EntityFrameworkCore;
using wpf_example.DB.Model;

namespace wpf_example.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WpfExample.db");
        }
    }
}
