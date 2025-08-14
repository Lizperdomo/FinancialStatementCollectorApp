using Learn.Api.Business.Objects.Entities.FinancialStatement;
using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Entities.Chargers; 
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

        // Chargers
        public DbSet<Charge> Charges { get; set; }
        public DbSet<AssociatedCharge> AssociatedCharges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Receipt
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

            //Charge
            modelBuilder.Entity<Charge>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Email).IsRequired().HasMaxLength(200);
                b.Property(x => x.AgreementNumber).IsRequired().HasMaxLength(50);
                b.Property(x => x.Description).HasMaxLength(500);
                b.Property(x => x.Debt).HasColumnType("decimal(18,2)");
                b.Property(x => x.Amount).HasColumnType("decimal(18,2)");
                b.Property(x => x.ReceiptFolio).IsRequired().HasMaxLength(64);
            });

            //  AssociatedCharge
            modelBuilder.Entity<AssociatedCharge>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.MiscIncomeType).IsRequired().HasMaxLength(120);
                b.Property(x => x.Amount).HasColumnType("decimal(18,2)");

                b.HasOne(x => x.Charge)
                 .WithMany(c => c.AssociatedCharges)
                 .HasForeignKey(x => x.ChargeId);
            });
        }
    }
}
