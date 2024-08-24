﻿// <auto-generated />
using System;
using Employees.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeepTrackr.Api.Migrations.EmployeeDb
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("emp")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Companies", "emp");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.CompanyItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employee_Company", "emp");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Employees", "emp");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Invitation", "emp");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Owners", "emp");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Company", b =>
                {
                    b.HasOne("Employees.Domain.InvitingEmployee.Owner", null)
                        .WithMany("Companies")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.CompanyItem", b =>
                {
                    b.HasOne("Employees.Domain.InvitingEmployee.Employee", null)
                        .WithMany("Companies")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Employee", b =>
                {
                    b.HasOne("Employees.Domain.InvitingEmployee.Owner", null)
                        .WithMany("Employees")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Invitation", b =>
                {
                    b.HasOne("Employees.Domain.InvitingEmployee.Owner", null)
                        .WithMany("Invitations")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Employee", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Employees.Domain.InvitingEmployee.Owner", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Employees");

                    b.Navigation("Invitations");
                });
#pragma warning restore 612, 618
        }
    }
}
