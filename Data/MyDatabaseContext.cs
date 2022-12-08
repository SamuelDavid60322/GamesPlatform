using GamesPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GamesPlatform.Data
{
    public class MyDatabaseContext : DbContext
    {
      public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options): base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
