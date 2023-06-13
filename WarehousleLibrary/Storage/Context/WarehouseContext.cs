using Microsoft.EntityFrameworkCore;
using Warehouse.Library.Entities;

namespace Warehouse.Library.Storage.Context
{
    public partial class WarehouseContext : DbContext
    {
        public WarehouseContext() 
        {
        }

        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options) 
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Transition> Transitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("uniqueidentifier");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(512);

                entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .HasColumnType("money");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Statuses");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("uniqueidentifier");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Transition>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("uniqueidentifier");

                entity.Property(e => e.TransitionDate)
                    .HasColumnName("TransitionDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Transitions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StatusTo)
                    .WithMany(p => p.TransitionsTo)
                    .HasForeignKey(d => d.StatusIdTo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
