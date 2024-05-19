using Microsoft.EntityFrameworkCore;
using AllGoods.Repository.Models;

namespace AllGoods.Repository.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<VariantAttribute> VariantAttributes { get; set; }
        public DbSet<VariantAttributeValue> VariantAttributeValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("EComDb_Connection_String");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductID);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SEOName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.WarehouseID);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.StockID);
                entity.HasOne(e => e.Variant)
                    .WithMany(v => v.Stocks)
                    .HasForeignKey(e => e.VariantID);
                entity.HasOne(e => e.Warehouse)
                    .WithMany(w => w.Stocks)
                    .HasForeignKey(e => e.WarehouseID);
                entity.Property(e => e.Quantity).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderID);
                entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.OrderItem)
                        .WithMany(e => e.Orders)
                        .HasForeignKey(e => e.OrderItemID);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemID);
                entity.HasOne(e => e.Variant)
                    .WithMany(v => v.OrderItems)
                    .HasForeignKey(e => e.VariantID);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.VariantAmount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<VariantAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeID);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<VariantAttributeValue>(entity =>
            {
                entity.HasKey(e => e.ValueID);
                entity.HasOne(e => e.VariantAttribute)
                    .WithMany(a => a.Values)
                    .HasForeignKey(e => e.AttributeID);
                entity.Property(e => e.Value).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.HasKey(e => e.VariantID);
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(e => e.ProductID);
                entity.HasOne(e => e.VariantAttribute)
                    .WithMany(a => a.Variants)
                    .HasForeignKey(e => e.AttributeID);
                entity.HasOne(e => e.VariantAttributeValue)
                    .WithMany(v => v.Variants)
                    .HasForeignKey(e => e.ValueID);
                entity.Property(e => e.Created_On).IsRequired().HasColumnType("datetime");
            });
        }
    }
}
