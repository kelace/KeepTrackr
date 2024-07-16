﻿// <auto-generated />
using System;
using Companies.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeepTrackr.Api.Migrations.CompanyDb
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20240709082802_Companies_Initial")]
    partial class Companies_Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("companies")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Companies.Domain.Company", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Name");

                    b.HasIndex("OwnerId");

                    b.ToTable("Company", "companies");
                });

            modelBuilder.Entity("Companies.Domain.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Owners", "companies");
                });

            modelBuilder.Entity("Companies.Domain.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AllowedCompaniesCount")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Subscription", "companies");
                });

            modelBuilder.Entity("Companies.Domain.SubscriptionType", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AllowedCompaniesCount")
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Type");

                    b.ToTable("SubscriptionTypes", "companies");

                    b.HasData(
                        new
                        {
                            Type = "Normal",
                            AllowedCompaniesCount = 10,
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Type = "Silver",
                            AllowedCompaniesCount = 25,
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Type = "Gold",
                            AllowedCompaniesCount = 50,
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Companies.Domain.Company", b =>
                {
                    b.HasOne("Companies.Domain.Owner", null)
                        .WithMany("Companies")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Companies.Domain.Subscription", b =>
                {
                    b.HasOne("Companies.Domain.Owner", null)
                        .WithOne("Subscription")
                        .HasForeignKey("Companies.Domain.Subscription", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Companies.Domain.Owner", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Subscription")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
