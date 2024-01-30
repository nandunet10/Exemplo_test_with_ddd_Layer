using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TestExecutionAec.Infrastructure.Contexts;

namespace TestExecutionAec.Infrastructure.Factories
{
    public class TestExecutionAecDbContextFactory : IDesignTimeDbContextFactory<TestExecutionDbContext>
    {
        public TestExecutionDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TestExecutionDbContext> builder = new DbContextOptionsBuilder<TestExecutionDbContext>();
            builder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=DB_Automacao;Trusted_Connection=True;",
                x => x.MigrationsHistoryTable("__MigrationsHistory", "dbo")
                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            return new TestExecutionDbContext(builder.Options);
        }
    }
}
