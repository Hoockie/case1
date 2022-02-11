using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KeysOne.Models
{
    public partial class MachineDrinksContext : DbContext
    {
        public MachineDrinksContext()
        {
        }

        public MachineDrinksContext(DbContextOptions<MachineDrinksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coin> Coins { get; set; } = null!;
        public virtual DbSet<Drink> Drinks { get; set; } = null!;
        public virtual DbSet<VendingMachine> VendingMachines { get; set; } = null!;
        public virtual DbSet<VendingMachineCoin> VendingMachineCoins { get; set; } = null!;
        public virtual DbSet<VendingMachineDrink> VendingMachineDrinks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Machine Drinks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coin>(entity =>
            {
                entity.HasKey(e => e.IdCoin)
                    .HasName("PK__Coins__37DAEAACAC281FFB");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.HasKey(e => e.IdDrink)
                    .HasName("PK__Drinks__00E5FFC0CAC05356");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Image).HasMaxLength(1);
            });

            modelBuilder.Entity<VendingMachine>(entity =>
            {
                entity.HasKey(e => e.IdVendingMachine)
                    .HasName("PK__VendingM__4677EA1A67CCA08F");

                entity.ToTable("VendingMachine");
            });

            modelBuilder.Entity<VendingMachineCoin>(entity =>
            {
                entity.HasKey(e => e.IdVendingMachineCoins)
                    .HasName("PK__VendingM__210902194798F667");

                entity.HasOne(d => d.IdCoinNavigation)
                    .WithMany(p => p.VendingMachineCoins)
                    .HasForeignKey(d => d.IdCoin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VendingMa__IdCoi__412EB0B6");

                entity.HasOne(d => d.IdVendingMachineNavigation)
                    .WithMany(p => p.VendingMachineCoins)
                    .HasForeignKey(d => d.IdVendingMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VendingMa__IdVen__403A8C7D");
            });

            modelBuilder.Entity<VendingMachineDrink>(entity =>
            {
                entity.HasKey(e => e.IdVendingMachineDrinks)
                    .HasName("PK__VendingM__EBC9BCFB223052EE");

                entity.HasOne(d => d.Drinks)
                    .WithMany(p => p.VendingMachineDrinks)
                    .HasForeignKey(d => d.DrinksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VendingMa__Drink__3D5E1FD2");

                entity.HasOne(d => d.IdVendingMachineNavigation)
                    .WithMany(p => p.VendingMachineDrinks)
                    .HasForeignKey(d => d.IdVendingMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VendingMa__IdVen__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
