using Learn.Api.Business.Objects.Entities.FinancialStatement;
using Learn.Api.BusinessObjects.Entities.Receipts;
using Microsoft.EntityFrameworkCore;

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

        //Entidad de recibos
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la entidad Receipt
            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Folio).IsRequired().HasMaxLength(50);
                entity.Property(r => r.HouseId).IsRequired().HasMaxLength(100);
                entity.Property(r => r.ResidentName).IsRequired().HasMaxLength(100);
                entity.Property(r => r.Concept).IsRequired().HasMaxLength(200);
                entity.Property(r => r.Amount).HasColumnType("decimal(18,2)");
                entity.Property(r => r.Discount).HasColumnType("decimal(18,2)");
                entity.Property(r => r.Surcharge).HasColumnType("decimal(18,2)");
                entity.Property(r => r.CreatedAt);
                entity.Property(r => r.Status).HasConversion<int>();
            });
        }
    }
}
