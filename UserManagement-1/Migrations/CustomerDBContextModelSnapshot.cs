﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement_1.Data;

namespace UserManagement_1.Migrations
{
    [DbContext(typeof(CustomerDBContext))]
    partial class CustomerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("UserManagement_1.Models.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CustAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustConfPass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CustMobile")
                        .HasColumnType("bigint");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustPassword")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustId");

                    b.ToTable("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
