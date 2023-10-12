﻿// <auto-generated />
using System;
using Licensing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licensing.Migrations
{
    [DbContext(typeof(LicenceContext))]
    partial class LicenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licensing.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("Licensing.Models.Licence", b =>
                {
                    b.Property<int>("LicenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LicenceId"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicenceId");

                    b.ToTable("Licence", (string)null);
                });

            modelBuilder.Entity("Licensing.Models.LicencePurchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("PurchaseId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LicenceId");

                    b.ToTable("LicencePurchase", (string)null);
                });

            modelBuilder.Entity("Licensing.Models.LicencePurchase", b =>
                {
                    b.HasOne("Licensing.Models.Company", "Company")
                        .WithMany("LicencePurchases")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Licensing.Models.Licence", "Licence")
                        .WithMany("LicencePurchases")
                        .HasForeignKey("LicenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Licence");
                });

            modelBuilder.Entity("Licensing.Models.Company", b =>
                {
                    b.Navigation("LicencePurchases");
                });

            modelBuilder.Entity("Licensing.Models.Licence", b =>
                {
                    b.Navigation("LicencePurchases");
                });
#pragma warning restore 612, 618
        }
    }
}