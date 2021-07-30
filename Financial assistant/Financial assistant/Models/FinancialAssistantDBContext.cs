using Microsoft.EntityFrameworkCore;
using Financial_assistant.Models.DbModels;
using Financial_assistant.Services.BaseDbServices.Extensions;

#nullable disable

namespace Financial_assistant.Models
{
    public class FinancialAssistantDBContext : DbContext
    {

        public FinancialAssistantDBContext(DbContextOptions<FinancialAssistantDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Convertation> Convertations { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BankAccount");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BankAccount_Currency");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BankAccount_User");

                entity.Property(e => e.IsDeleted)
                    .IsRequired();

                entity.IsSoftDelete();
            });

            modelBuilder.Entity<Convertation>(entity =>
            {
                entity.ToTable("Convertation");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CurrencyFrom)
                    .WithMany(p => p.ConvertationCurrencyFroms)
                    .HasForeignKey(d => d.CurrencyFromId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ConvertationFrom_Currency");

                entity.HasOne(d => d.CurrencyTo)
                    .WithMany(p => p.ConvertationCurrencyTos)
                    .HasForeignKey(d => d.CurrencyToId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ConvertationTo_Currency");

                entity.Property(e => e.IsDeleted)
                    .IsRequired();

                entity.IsSoftDelete();
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasMany(x => x.ConvertationCurrencyFroms).WithOne(x => x.CurrencyFrom).HasForeignKey(x => x.CurrencyFromId).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.ConvertationCurrencyTos).WithOne(x => x.CurrencyTo).HasForeignKey(x => x.CurrencyToId).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.IsDeleted)
                    .IsRequired();

                entity.IsSoftDelete();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.BankAccount)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Transaction_BankAccount");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Transaction_Currency");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Transaction_TransactionType");

                entity.Property(e => e.IsDeleted)
                    .IsRequired();

                entity.IsSoftDelete();
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransactionTypes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TransactionType_User");

                entity.Property(e => e.IsDeleted)
                    .IsRequired();

                entity.IsSoftDelete();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.County)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IsDeleted)
                    .IsRequired();

                entity.IsSoftDelete();
            });

        }
    }
}
