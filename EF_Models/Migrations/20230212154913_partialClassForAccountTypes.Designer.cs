﻿// <auto-generated />
using System;
using EF_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFcoreTesting.Migrations
{
    [DbContext(typeof(MaelstromContext))]
    [Migration("20230212154913_partialClassForAccountTypes")]
    partial class partialClassForAccountTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFcoreTesting.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"), 1L, 1);

                    b.Property<int>("AccountStandingID")
                        .HasColumnType("int");

                    b.Property<int>("AccountTypeID")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateOrProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.HasIndex("AccountStandingID");

                    b.HasIndex("AccountTypeID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EFcoreTesting.Models.AccountPayment", b =>
                {
                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("PaymentID")
                        .HasColumnType("int");

                    b.HasKey("AccountID", "PaymentID");

                    b.HasIndex("PaymentID");

                    b.ToTable("AccountPayments");
                });

            modelBuilder.Entity("EFcoreTesting.Models.AccountStanding", b =>
                {
                    b.Property<int>("AccountStandingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountStandingID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountStandingID");

                    b.ToTable("AccountStandings");

                    b.HasData(
                        new
                        {
                            AccountStandingID = 1,
                            Name = "Current"
                        },
                        new
                        {
                            AccountStandingID = 2,
                            Name = "NotCurrent"
                        });
                });

            modelBuilder.Entity("EFcoreTesting.Models.AccountType", b =>
                {
                    b.Property<int>("AccountTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountTypeID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TermLengthDays")
                        .HasColumnType("int");

                    b.HasKey("AccountTypeID");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            AccountTypeID = 1,
                            Name = "PremiumMonthly",
                            TermLengthDays = 30
                        },
                        new
                        {
                            AccountTypeID = 2,
                            Name = "PremiumYearly",
                            TermLengthDays = 365
                        },
                        new
                        {
                            AccountTypeID = 3,
                            Name = "Trail",
                            TermLengthDays = 14
                        });
                });

            modelBuilder.Entity("EFcoreTesting.Models.Fish", b =>
                {
                    b.Property<int>("FishID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FishID"), 1L, 1);

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("FishTypeID")
                        .HasColumnType("int");

                    b.Property<byte>("Image")
                        .HasColumnType("tinyint");

                    b.Property<string>("NameOrTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.HasKey("FishID");

                    b.HasIndex("FishTypeID");

                    b.HasIndex("SiteID");

                    b.ToTable("Fishs");
                });

            modelBuilder.Entity("EFcoreTesting.Models.FishType", b =>
                {
                    b.Property<int>("FishTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FishTypeID"), 1L, 1);

                    b.Property<string>("CommonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("MaxSize")
                        .HasColumnType("float");

                    b.Property<double?>("MaxTemp")
                        .HasColumnType("float");

                    b.Property<double?>("MinTemp")
                        .HasColumnType("float");

                    b.Property<double?>("PhMax")
                        .HasColumnType("float");

                    b.Property<double?>("PhMin")
                        .HasColumnType("float");

                    b.Property<int?>("RecommendedTankSize")
                        .HasColumnType("int");

                    b.Property<string>("ScientificName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FishTypeID");

                    b.ToTable("FishTypes");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"), 1L, 1);

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Site", b =>
                {
                    b.Property<int>("SiteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteID"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteTypeID")
                        .HasColumnType("int");

                    b.HasKey("SiteID");

                    b.HasIndex("SiteTypeID");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("EFcoreTesting.Models.SiteType", b =>
                {
                    b.Property<int>("SiteTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteTypeID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteTypeID");

                    b.ToTable("SiteType");
                });

            modelBuilder.Entity("EFcoreTesting.Models.SiteUser", b =>
                {
                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SiteID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("SiteUsers");
                });

            modelBuilder.Entity("EFcoreTesting.Models.TestResult", b =>
                {
                    b.Property<int>("TestResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestResultID"), 1L, 1);

                    b.Property<decimal?>("Alkalinty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Ammonia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Calcium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Magnesium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Nitrate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Nitrite")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float?>("Ph")
                        .HasColumnType("real");

                    b.Property<decimal?>("Phosphate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Sality")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.Property<float?>("Temperature")
                        .HasColumnType("real");

                    b.HasKey("TestResultID");

                    b.HasIndex("SiteID");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("EFcoreTesting.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("AccountID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Account", b =>
                {
                    b.HasOne("EFcoreTesting.Models.AccountStanding", "AccountStanding")
                        .WithMany()
                        .HasForeignKey("AccountStandingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFcoreTesting.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountStanding");

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("EFcoreTesting.Models.AccountPayment", b =>
                {
                    b.HasOne("EFcoreTesting.Models.Account", "Account")
                        .WithMany("AccountPayments")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFcoreTesting.Models.Payment", "Payments")
                        .WithMany("AccountPayments")
                        .HasForeignKey("PaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Fish", b =>
                {
                    b.HasOne("EFcoreTesting.Models.FishType", "FishType")
                        .WithMany("Fishs")
                        .HasForeignKey("FishTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFcoreTesting.Models.Site", "Site")
                        .WithMany("Fishs")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FishType");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Site", b =>
                {
                    b.HasOne("EFcoreTesting.Models.SiteType", "SiteType")
                        .WithMany("Sites")
                        .HasForeignKey("SiteTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiteType");
                });

            modelBuilder.Entity("EFcoreTesting.Models.SiteUser", b =>
                {
                    b.HasOne("EFcoreTesting.Models.Site", "Site")
                        .WithMany("SiteUsers")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFcoreTesting.Models.User", "User")
                        .WithMany("SiteUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFcoreTesting.Models.TestResult", b =>
                {
                    b.HasOne("EFcoreTesting.Models.Site", "Site")
                        .WithMany("TestResults")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("EFcoreTesting.Models.User", b =>
                {
                    b.HasOne("EFcoreTesting.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Account", b =>
                {
                    b.Navigation("AccountPayments");
                });

            modelBuilder.Entity("EFcoreTesting.Models.FishType", b =>
                {
                    b.Navigation("Fishs");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Payment", b =>
                {
                    b.Navigation("AccountPayments");
                });

            modelBuilder.Entity("EFcoreTesting.Models.Site", b =>
                {
                    b.Navigation("Fishs");

                    b.Navigation("SiteUsers");

                    b.Navigation("TestResults");
                });

            modelBuilder.Entity("EFcoreTesting.Models.SiteType", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("EFcoreTesting.Models.User", b =>
                {
                    b.Navigation("SiteUsers");
                });
#pragma warning restore 612, 618
        }
    }
}