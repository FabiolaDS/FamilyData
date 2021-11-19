using FamilyData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FamilyData.Persistence
{
    public class AdultDbContext : DbContext
    {
      public DbSet<Adult> Adults { get; set; }
      public DbSet<Job> Jobs { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          optionsBuilder.UseSqlite("Data Source=adult.sqlite");
      }
    }
}