using Microsoft.EntityFrameworkCore;
using Learn.Api.Business.Objects.Entities.FinancialStatement;

namespace Learn.Api.Repository.EFCore
{
    public class AppLearnContext : DbContext
    {
        public AppLearnContext(DbContextOptions<AppLearnContext> options)
            : base(options)
        {
        }

        public DbSet<VisualizeAccount> VisualizeAccounts { get; set; }
        public DbSet<VisualizeHomes> VisualizeHomes { get; set; }
        public DbSet<SearchAccount> SearchAccount { get; set; }
        public DbSet<MonthlyFees> MonthlyFees { get; set; }
    }
}
