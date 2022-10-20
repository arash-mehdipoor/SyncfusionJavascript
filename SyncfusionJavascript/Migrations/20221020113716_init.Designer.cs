﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SyncfusionJavascript.Context;

#nullable disable

namespace SyncfusionJavascript.Migrations
{
    [DbContext(typeof(SyncfusionDbContext))]
    [Migration("20221020113716_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("SyncfusionJavascript.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Address",
                            Age = 79,
                            Birthdate = new DateTime(1943, 10, 20, 15, 7, 16, 74, DateTimeKind.Local).AddTicks(9929),
                            City = "City",
                            FirstName = "Arash",
                            LastName = "Mahdipour",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Address = "Address",
                            Age = 22,
                            Birthdate = new DateTime(2000, 10, 20, 15, 7, 16, 74, DateTimeKind.Local).AddTicks(9983),
                            City = "City",
                            FirstName = "Roya",
                            LastName = "Mirzavand",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Address = "Address",
                            Age = 66,
                            Birthdate = new DateTime(1956, 10, 20, 15, 7, 16, 74, DateTimeKind.Local).AddTicks(9988),
                            City = "City",
                            FirstName = "Seyed",
                            LastName = "Ramezani",
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            Address = "Address",
                            Age = 34,
                            Birthdate = new DateTime(1988, 10, 20, 15, 7, 16, 75, DateTimeKind.Local).AddTicks(9),
                            City = "City",
                            FirstName = "Sara",
                            LastName = "Gohartoor",
                            Status = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}