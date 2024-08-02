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
    [Migration("20240722082808_Tasks_BoarsCards")]
    partial class Tasks_BoarsCards
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

            modelBuilder.Entity("TaskManagment.Domain.Boards.Board", b =>
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

            modelBuilder.Entity("TaskManagment.Domain.Cards.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("TaskManagment.Domain.Executor", b =>
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

            modelBuilder.Entity("TaskManagment.Domain.LabelLineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LabelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LabelId")
                        .IsUnique();

                    b.HasIndex("TaskId");

                    b.ToTable("LabelLineItem", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Labels.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Label", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignedTo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssignedTo")
                        .IsUnique();

                    b.ToTable("Tasks", "task");
                });

            modelBuilder.Entity("TaskManagment.Domain.Boards.Board", b =>
                {
                    b.OwnsOne("TaskManagment.Domain.Boards.CompanyId", "CompanyId", b1 =>
                        {
                            b1.Property<Guid>("BoardId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CompanyName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("CompanyOwnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("BoardId");

                            b1.ToTable("Boards", "task");

                            b1.WithOwner()
                                .HasForeignKey("BoardId");
                        });

                    b.Navigation("CompanyId")
                        .IsRequired();
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

            modelBuilder.Entity("TaskManagment.Domain.LabelLineItem", b =>
                {
                    b.HasOne("TaskManagment.Domain.Labels.Label", null)
                        .WithOne()
                        .HasForeignKey("TaskManagment.Domain.LabelLineItem", "LabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagment.Domain.Task", null)
                        .WithMany("Labels")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagment.Domain.Task", b =>
                {
                    b.HasOne("TaskManagment.Domain.Executor", null)
                        .WithOne()
                        .HasForeignKey("TaskManagment.Domain.Task", "AssignedTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagment.Domain.Task", b =>
                {
                    b.Navigation("Labels");
                });
#pragma warning restore 612, 618
        }
    }
}
