using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Demo2.Infrastructure;

namespace Demo2.Migrations
{
    [DbContext(typeof(RemontOnlineDbContext))]
    [Migration("20161115160418_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo2.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CallMasterTime")
                        .HasColumnName("CallMasterTime");

                    b.Property<string>("Comment")
                        .HasColumnName("Comment")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<DateTime>("DeadlineTime")
                        .HasColumnName("DeadlineTime");

                    b.Property<bool>("IsUrgently")
                        .HasColumnName("IsUrgently");

                    b.Property<string>("OrderNumber")
                        .HasColumnName("OrderNumber");

                    b.Property<int>("OrderStatusId");

                    b.Property<int>("OrderTypeId");

                    b.Property<decimal>("PrepaidExpense");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Demo2.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("Index_Name");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("Demo2.Entities.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");
                });

            modelBuilder.Entity("Demo2.Entities.Order", b =>
                {
                    b.HasOne("Demo2.Entities.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Demo2.Entities.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
