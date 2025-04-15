using VME.incasso.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace VME.incasso.Data.DbContexts
{
    public class VMEIncassoContext : DbContext
    {
        public VMEIncassoContext(DbContextOptions<VMEIncassoContext> options) : base(options) { }

        // DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<DebtRecord> DebtRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AdminSettings> AdminSettings { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; } // New
        public DbSet<AuditLog> AuditLogs { get; set; } // New

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Base configurations for all entities
            modelBuilder.Ignore<BaseEntity>();

            // User relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // RefreshToken relationships
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany()
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AuditLog relationships
            modelBuilder.Entity<AuditLog>()
                .HasOne(al => al.User)
                .WithMany()
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company relationships
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Buildings)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Building relationships
            modelBuilder.Entity<Building>()
                .HasOne(b => b.Company)
                .WithMany(c => c.Buildings)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Building>()
                .HasMany(b => b.Debtors)
                .WithOne(d => d.Building)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Debtor relationships
            modelBuilder.Entity<Debtor>()
                .HasOne(d => d.Building)
                .WithMany(b => b.Debtors)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Debtor>()
                .HasMany(d => d.DebtRecords)
                .WithOne(dr => dr.Debtor)
                .HasForeignKey(dr => dr.DebtorId)
                .OnDelete(DeleteBehavior.Cascade);

            // DebtRecord relationships
            modelBuilder.Entity<DebtRecord>()
                .HasOne(dr => dr.Debtor)
                .WithMany(d => d.DebtRecords)
                .HasForeignKey(dr => dr.DebtorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DebtRecord>()
                .HasMany(dr => dr.Notifications)
                .WithOne(n => n.DebtRecord)
                .HasForeignKey(n => n.DebtRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            // Notification relationships
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.DebtRecord)
                .WithMany(dr => dr.Notifications)
                .HasForeignKey(n => n.DebtRecordId)
                .OnDelete(DeleteBehavior.Restrict);

            // AdminSettings configuration (single configuration entry)
            modelBuilder.Entity<AdminSettings>()
                .HasKey(a => a.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
