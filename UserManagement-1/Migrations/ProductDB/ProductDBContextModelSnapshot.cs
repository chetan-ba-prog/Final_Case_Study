﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement_1.Data;

namespace UserManagement_1.Migrations.ProductDB
{
    [DbContext(typeof(ProductDBContext))]
    partial class ProductDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("UserManagement_1.Models.Product", b =>
                {
                    b.Property<int>("ProdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ProdCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ProdDiscount")
                        .HasColumnType("real");

                    b.Property<string>("ProdImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ProdPrice")
                        .HasColumnType("real");

                    b.Property<string>("ProdStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("ProdId");

                    b.ToTable("product");
                });
#pragma warning restore 612, 618
        }
    }
}
