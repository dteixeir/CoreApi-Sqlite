using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using dotNetApi.Domain;

namespace dotNetApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170716030302_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("dotNetApi.Domain.Beer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32);

                    b.Property<int>("AlcoholByVolume");

                    b.Property<string>("Brewery_Id")
                        .HasMaxLength(32);

                    b.Property<string>("Category_Id")
                        .HasMaxLength(32);

                    b.Property<string>("Description");

                    b.Property<string>("Filepath");

                    b.Property<int>("InternationalBitternessUnits");

                    b.Property<string>("Name");

                    b.Property<int>("StandardReferenceMethod");

                    b.Property<string>("Style_Id")
                        .HasMaxLength(32);

                    b.Property<int>("UniversalProductCode");

                    b.HasKey("Id");

                    b.HasIndex("Brewery_Id");

                    b.HasIndex("Category_Id");

                    b.HasIndex("Style_Id");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("dotNetApi.Domain.Brewery", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Code");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("FilePath");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Breweries");
                });

            modelBuilder.Entity("dotNetApi.Domain.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("dotNetApi.Domain.Style", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32);

                    b.Property<string>("Category_Id")
                        .HasMaxLength(32);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("dotNetApi.Domain.Beer", b =>
                {
                    b.HasOne("dotNetApi.Domain.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("Brewery_Id");

                    b.HasOne("dotNetApi.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_Id");

                    b.HasOne("dotNetApi.Domain.Style", "Style")
                        .WithMany()
                        .HasForeignKey("Style_Id");
                });

            modelBuilder.Entity("dotNetApi.Domain.Style", b =>
                {
                    b.HasOne("dotNetApi.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_Id");
                });
        }
    }
}
