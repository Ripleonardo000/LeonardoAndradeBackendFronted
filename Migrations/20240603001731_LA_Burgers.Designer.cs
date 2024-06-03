﻿// <auto-generated />
using LeonardoAndradeBackendMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeonardoAndradeBackendMVC.Migrations
{
    [DbContext(typeof(LA_MVCContext))]
    [Migration("20240603001731_LA_Burgers")]
    partial class LA_Burgers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LeonardoAndradeBackendMVC.Models.LA_Burger", b =>
                {
                    b.Property<int>("BurgerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurgerID"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("BurgerID");

                    b.ToTable("LA_Burger");
                });

            modelBuilder.Entity("LeonardoAndradeBackendMVC.Models.LA_Promo", b =>
                {
                    b.Property<int>("PromoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromoID"));

                    b.Property<int>("BurgerID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FechaPromo")
                        .HasColumnType("int");

                    b.HasKey("PromoID");

                    b.HasIndex("BurgerID");

                    b.ToTable("LA_Promo");
                });

            modelBuilder.Entity("LeonardoAndradeBackendMVC.Models.LA_Promo", b =>
                {
                    b.HasOne("LeonardoAndradeBackendMVC.Models.LA_Burger", "burger")
                        .WithMany("LA_Promo")
                        .HasForeignKey("BurgerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("burger");
                });

            modelBuilder.Entity("LeonardoAndradeBackendMVC.Models.LA_Burger", b =>
                {
                    b.Navigation("LA_Promo");
                });
#pragma warning restore 612, 618
        }
    }
}
