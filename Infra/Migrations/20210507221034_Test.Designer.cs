﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportEU.Infra;

namespace Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210507221034_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportEU.Data.AthleteData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstMidName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("SportEU.Data.CoachData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstMidName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("SportEU.Data.GroupAssignmentData", b =>
                {
                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AthleteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("GroupId", "AthleteId");

                    b.ToTable("GroupAssignments");
                });

            modelBuilder.Entity("SportEU.Data.GroupData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AthleteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoachId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}