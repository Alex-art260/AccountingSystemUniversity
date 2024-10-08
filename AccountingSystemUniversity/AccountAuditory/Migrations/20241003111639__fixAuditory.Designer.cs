﻿// <auto-generated />
using AccountAuditory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccountAuditory.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241003111639__fixAuditory")]
    partial class _fixAuditory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccountAuditory.Models.Auditory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("TypeRoomId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("TypeRoomId");

                    b.ToTable("Auditory", "public");
                });

            modelBuilder.Entity("AccountAuditory.Models.Buildings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Buildings", "public");
                });

            modelBuilder.Entity("AccountAuditory.Models.TypeRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TypeRoom", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "лекционное"
                        },
                        new
                        {
                            Id = 2,
                            Name = "для практических занятий"
                        },
                        new
                        {
                            Id = 3,
                            Name = "спортзал"
                        },
                        new
                        {
                            Id = 4,
                            Name = "пр."
                        });
                });

            modelBuilder.Entity("AccountAuditory.Models.Auditory", b =>
                {
                    b.HasOne("AccountAuditory.Models.Buildings", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccountAuditory.Models.TypeRoom", "TypeRoom")
                        .WithMany()
                        .HasForeignKey("TypeRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("TypeRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
