﻿// <auto-generated />
using System;
using Entity_Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity_Framework.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240611064230_ColumnCategoryImpact")]
    partial class ColumnCategoryImpact
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity_Framework.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryImpact")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Entity_Framework.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("Entity_Framework.Models.Task", b =>
                {
                    b.HasOne("Entity_Framework.Models.Category", "Category")
                        .WithMany("Task")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entity_Framework.Models.Category", b =>
                {
                    b.Navigation("Task");
                });
#pragma warning restore 612, 618
        }
    }
}