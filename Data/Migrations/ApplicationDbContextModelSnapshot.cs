﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Mail.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Vnumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mails", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Mail.MailStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DateSent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MailId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Printed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Read")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("VNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MailId")
                        .IsUnique();

                    b.ToTable("MailStatuses", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Mail.MailStatus", b =>
                {
                    b.HasOne("Core.Entities.Mail.Mail", "Mail")
                        .WithOne("MailStatus")
                        .HasForeignKey("Core.Entities.Mail.MailStatus", "MailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");
                });

            modelBuilder.Entity("Core.Entities.Mail.Mail", b =>
                {
                    b.Navigation("MailStatus")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
