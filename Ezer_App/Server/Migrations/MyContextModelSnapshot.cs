﻿// <auto-generated />
using System;
using Ezer_App.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ezer_App.Server.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ezer_App.Shared.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressState")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressZipcode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DoulaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyFirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDoula")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMidwife")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MidwifeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SpouseFirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SpouseLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SpouseNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ezer_App.Shared.WeekData", b =>
                {
                    b.Property<int>("WeekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BabyActivity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BabyImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BabySize")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("KeyTakeawaysBottom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("KeyTakeawaysList")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WeekLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WeekId");

                    b.ToTable("TheBumpData");
                });
#pragma warning restore 612, 618
        }
    }
}
