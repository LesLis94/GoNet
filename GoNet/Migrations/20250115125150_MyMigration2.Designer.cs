﻿// <auto-generated />
using System;
using GoNet.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoNet.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250115125150_MyMigration2")]
    partial class MyMigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GoNet.BL.Services.Abstract.PlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Cash")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GoNet.DataAccess.Abstract.ThingPlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdPlayer")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdPlayer");

                    b.ToTable("Things");
                });

            modelBuilder.Entity("GoNet.DataAccess.Abstract.ThingPlayerEntity", b =>
                {
                    b.HasOne("GoNet.BL.Services.Abstract.PlayerEntity", "Player")
                        .WithMany("Things")
                        .HasForeignKey("IdPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GoNet.BL.Services.Abstract.PlayerEntity", b =>
                {
                    b.Navigation("Things");
                });
#pragma warning restore 612, 618
        }
    }
}
