using Microsoft.EntityFrameworkCore;
using TestExecutionAec.Domain.AggregatesModel;
using TestExecutionAec.Infrastructure.EntityConfigurations;

namespace TestExecutionAec.Infrastructure.Contexts
{
    public class TestExecutionDbContext : DbContext
    {
        public TestExecutionDbContext(DbContextOptions<TestExecutionDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLazyLoadingProxies(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Schema
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new CardEntityTypeConfiguration());

        }

    }
}
