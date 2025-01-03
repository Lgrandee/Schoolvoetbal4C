﻿// <auto-generated />
using System;
using BoekenOnline.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Schoolvoetbalapp.Migrations
{
    [DbContext(typeof(SchoolvoetbalOnlineContext))]
    [Migration("20241217164638_yea")]
    partial class yea
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Schoolvoetbalapp.Models.Gokker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Gebruikersnaam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Gokkers");
                });

            modelBuilder.Entity("Schoolvoetbalapp.Models.Wedstrijd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GokkerId")
                        .HasColumnType("int");

                    b.Property<string>("Teams")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Wedbedrag")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("GokkerId");

                    b.ToTable("Wedstrijden");
                });

            modelBuilder.Entity("Schoolvoetbalapp.Models.Wedstrijd", b =>
                {
                    b.HasOne("Schoolvoetbalapp.Models.Gokker", null)
                        .WithMany("GeplaatsteWeddenschappen")
                        .HasForeignKey("GokkerId");
                });

            modelBuilder.Entity("Schoolvoetbalapp.Models.Gokker", b =>
                {
                    b.Navigation("GeplaatsteWeddenschappen");
                });
#pragma warning restore 612, 618
        }
    }
}
