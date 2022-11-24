﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(IndContext))]
    [Migration("20221122145959_Fixes_migration")]
    partial class Fixes_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmergencyShelterId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LanguagesSpoken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyShelterId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Entities.Customer_Message", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("StatusPrinted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("StatusReceived")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CustomerId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("Customer_Messages");
                });

            modelBuilder.Entity("Core.Entities.EmergencyShelter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CustomerAmount")
                        .HasColumnType("int");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EmergencyShelters");
                });

            modelBuilder.Entity("Core.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Core.Entities.Pole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmergencyShelterId")
                        .HasColumnType("int");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyShelterId");

                    b.ToTable("Poles");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.HasOne("Core.Entities.EmergencyShelter", "EmergencyShelter")
                        .WithMany("Customers")
                        .HasForeignKey("EmergencyShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmergencyShelter");
                });

            modelBuilder.Entity("Core.Entities.Customer_Message", b =>
                {
                    b.HasOne("Core.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Core.Entities.Message", b =>
                {
                    b.HasOne("Core.Entities.Customer", "Customer")
                        .WithMany("Messages")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Core.Entities.Pole", b =>
                {
                    b.HasOne("Core.Entities.EmergencyShelter", "EmergencyShelter")
                        .WithMany()
                        .HasForeignKey("EmergencyShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmergencyShelter");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Core.Entities.EmergencyShelter", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
