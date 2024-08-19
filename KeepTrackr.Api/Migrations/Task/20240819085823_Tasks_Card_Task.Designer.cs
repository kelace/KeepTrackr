﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagment.Infrastructure.Persistance;

#nullable disable

namespace KeepTrackr.Api.Migrations.Task
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240819085823_Tasks_Card_Task")]
    partial class Tasks_Card_Task
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("task")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagment.Domain.Boards.Column", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CardsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Boards", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.CardTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CardId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("CardId1");

                    b.ToTable("Tasks", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Cards.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cards", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Cards.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CardId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("CardId1");

                    b.ToTable("Label", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Companies.Desk", b =>
                {
                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CompanyName", "OwnerId");

                    b.ToTable("Companies", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Executors.Company", b =>
                {
                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserAssignedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OwnerId", "Name");

                    b.HasIndex("UserAssignedId");

                    b.ToTable("Executors_Company", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Executors.Executor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExecutorType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Executors", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Boards.Column", b =>
                {
                    b.OwnsOne("TaskManagment.Domain.Boards.CompanyId", "CompanyId", b1 =>
                        {
                            b1.Property<Guid>("ColumnId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CompanyName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("CompanyOwnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ColumnId");

                            b1.ToTable("Boards", "task");

                            b1.WithOwner()
                                .HasForeignKey("ColumnId");
                        });

                    b.Navigation("CompanyId")
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagment.Domain.CardTask", b =>
                {
                    b.HasOne("TaskManagment.Domain.Cards.Card", null)
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagment.Domain.Cards.Card", null)
                        .WithMany("Tasks")
                        .HasForeignKey("CardId1");
                });

            modelBuilder.Entity("TaskManagment.Domain.Cards.Card", b =>
                {
                    b.OwnsOne("TaskManagment.Domain.Cards.CompanyId", "CompanyId", b1 =>
                        {
                            b1.Property<Guid>("CardId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CompanyName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("CompanyOwnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("CardId");

                            b1.ToTable("Cards", "task");

                            b1.WithOwner()
                                .HasForeignKey("CardId");
                        });

                    b.Navigation("CompanyId")
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagment.Domain.Cards.Label", b =>
                {
                    b.HasOne("TaskManagment.Domain.Cards.Card", null)
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagment.Domain.Cards.Card", null)
                        .WithMany("Labels")
                        .HasForeignKey("CardId1");
                });

            modelBuilder.Entity("TaskManagment.Domain.Executors.Company", b =>
                {
                    b.HasOne("TaskManagment.Domain.Executors.Executor", null)
                        .WithMany("Companies")
                        .HasForeignKey("UserAssignedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagment.Domain.Cards.Card", b =>
                {
                    b.Navigation("Labels");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagment.Domain.Executors.Executor", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
