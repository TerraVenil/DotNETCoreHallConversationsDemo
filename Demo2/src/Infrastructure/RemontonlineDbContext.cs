using Demo2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Infrastructure
{
    public class RemontOnlineDbContext : DbContext
    {
        public DbSet<OrderType> OrderTypes { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public RemontOnlineDbContext(DbContextOptions options) : base(options)
        {    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderType>(
                entity =>
                {
                    entity.HasKey(x => x.Id);

                    entity.Property(x => x.Id).HasColumnName("Id");
                    entity.Property(x => x.Name)
                          .HasColumnName("Name")
                          .IsRequired()
                          .HasMaxLength(255);

                    entity.ToTable("OrderTypes");
                });

            modelBuilder.Entity<OrderStatus>(
                entity =>
                {
                    entity.HasKey(x => x.Id);

                    entity.Property(x => x.Id).HasColumnName("Id");
                    entity.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);

                    entity.HasIndex(x => x.Name).HasName("Index_Name");

                    entity.ToTable("OrderStatuses");
                });

            modelBuilder.Entity<Order>(
                entity =>
                {
                    entity.HasKey(x => x.Id);

                    entity.Property(x => x.Id).HasColumnName("Id");
                    entity.Property(x => x.OrderNumber).HasColumnName("OrderNumber");

                    entity.Property(t => t.OrderTypeId).IsRequired().ValueGeneratedNever();
                    entity.HasOne(x => x.OrderType);

                    entity.Property(t => t.OrderStatusId).IsRequired().ValueGeneratedNever();
                    entity.HasOne(x => x.OrderStatus);

                    entity.Property(x => x.Comment).HasColumnName("Comment").HasMaxLength(255);
                    entity.Property(x => x.CallMasterTime).HasColumnName("CallMasterTime").IsRequired();
                    entity.Property(x => x.DeadlineTime).HasColumnName("DeadlineTime").IsRequired();
                    entity.Property(x => x.Price).HasColumnName("Price").IsRequired();
                    entity.Property(x => x.PrepaidExpense);
                    entity.Property(x => x.IsUrgently).HasColumnName("IsUrgently");

                    entity.ToTable("Orders");
                });
        }
    }
}