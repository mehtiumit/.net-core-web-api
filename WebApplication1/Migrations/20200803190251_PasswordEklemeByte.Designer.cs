﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200803190251_PasswordEklemeByte")]
    partial class PasswordEklemeByte
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Add", b =>
                {
                    b.Property<int>("AddId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Adds");
                });

            modelBuilder.Entity("WebApplication1.Models.AddAndCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("AddId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "AddId");

                    b.HasIndex("AddId");

                    b.ToTable("AddAndCategories");
                });

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApplication1.Models.FavAds", b =>
                {
                    b.Property<int>("AddId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavAds");
                });

            modelBuilder.Entity("WebApplication1.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddsAddId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoId");

                    b.HasIndex("AddsAddId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("password1")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("passwordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordSalt1")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.Add", b =>
                {
                    b.HasOne("WebApplication1.Models.Category", "Category")
                        .WithMany("Adds")
                        .HasForeignKey("CategoryId");

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("Adds")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApplication1.Models.AddAndCategory", b =>
                {
                    b.HasOne("WebApplication1.Models.Add", "Add")
                        .WithMany("AddAndCategories")
                        .HasForeignKey("AddId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Category", "Category")
                        .WithMany("AddAndCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.FavAds", b =>
                {
                    b.HasOne("WebApplication1.Models.Add", "Add")
                        .WithMany("FavAdss")
                        .HasForeignKey("AddId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("FavAdss")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Photo", b =>
                {
                    b.HasOne("WebApplication1.Models.Add", "Adds")
                        .WithMany("Photos")
                        .HasForeignKey("AddsAddId");
                });
#pragma warning restore 612, 618
        }
    }
}
