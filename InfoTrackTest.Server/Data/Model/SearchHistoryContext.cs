using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InfoTrackTest.Server.Data.Model
{
    public class SearchHistoryContext : DbContext
    {
        public SearchHistoryContext(DbContextOptions<SearchHistoryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<SearchHistory> SearchCountHistory { get; set; }
    }
}
