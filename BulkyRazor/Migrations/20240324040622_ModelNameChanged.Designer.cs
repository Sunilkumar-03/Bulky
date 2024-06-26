﻿// <auto-generated />
using BulkyRazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyRazor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240324040622_ModelNameChanged")]
    partial class ModelNameChanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyRazor.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<int>("CategoryOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 101,
                            CategoryOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            CategoryId = 102,
                            CategoryOrder = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            CategoryId = 103,
                            CategoryOrder = 3,
                            Name = "Romance"
                        },
                        new
                        {
                            CategoryId = 104,
                            CategoryOrder = 4,
                            Name = "Drama"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
