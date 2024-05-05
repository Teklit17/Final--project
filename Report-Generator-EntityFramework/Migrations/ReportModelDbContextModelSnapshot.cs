﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Report_Generator_EntityFramework;

#nullable disable

namespace Report_Generator_EntityFramework.Migrations
{
    [DbContext(typeof(ReportModelDbContext))]
    partial class ReportModelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Domain.Models.ReportImageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReportModelId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReportModelId");

                    b.ToTable("ReportImageModels");
                });

            modelBuilder.Entity("Domain.Models.ReportModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kunde")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ReportModels");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.ConcreteDensityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("DataFraOpdragsgiverId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Dato")
                        .HasColumnType("TEXT");

                    b.Property<double>("Densitet")
                        .HasColumnType("REAL");

                    b.Property<double>("MasseILuft")
                        .HasColumnType("REAL");

                    b.Property<double>("MasseIVannbad")
                        .HasColumnType("REAL");

                    b.Property<double>("Pw")
                        .HasColumnType("REAL");

                    b.Property<double>("V")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DataFraOpdragsgiverId");

                    b.ToTable("concreteDensityModels");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.DataEtterKuttingOgSlipingModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DataFraOpdragsgiverId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Dm")
                        .HasColumnType("REAL");

                    b.Property<double>("DmPrøvetykkeRatio")
                        .HasColumnType("REAL");

                    b.Property<double>("EtterSliping")
                        .HasColumnType("REAL");

                    b.Property<string>("FasthetSammenligning")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("FørSliping")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("IvannbadDato")
                        .HasColumnType("TEXT");

                    b.Property<double>("MmTilTopp")
                        .HasColumnType("REAL");

                    b.Property<string>("Overflatetilstand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Prøvetykke")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("TestDato")
                        .HasColumnType("TEXT");

                    b.Property<double>("TrykkfasthetMPa")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DataFraOpdragsgiverId");

                    b.ToTable("DataEtterKuttingOgSlipingModels");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.DataFraOppdragsgiverPrøverModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Datomottatt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dmax")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KjerneImax")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KjerneImin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Overdekningoppgitt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OverflateOK")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OverflateUK")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReportModelId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReportModelId");

                    b.ToTable("DataFraOppdragsgiverPrøverModels");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.TestModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReportModelId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReportModelId");

                    b.ToTable("tests");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.TrykktestingModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DataFraOpdragsgiverId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PalastHastighetMPas")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TrykkfasthetMPa")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TrykkfasthetMPaNSE")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TrykkflateMm")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DataFraOpdragsgiverId");

                    b.ToTable("trykktestingModels");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.verktøyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReportModelId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReportModelId");

                    b.ToTable("verktøies");
                });

            modelBuilder.Entity("Domain.Models.ReportImageModel", b =>
                {
                    b.HasOne("Domain.Models.ReportModel", "ReportModel")
                        .WithMany("Images")
                        .HasForeignKey("ReportModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportModel");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.ConcreteDensityModel", b =>
                {
                    b.HasOne("Report_Generator_Domain.Models.DataFraOppdragsgiverPrøverModel", "DataFraOppdragsgiverPrøverModel")
                        .WithMany("ConcreteDensityModel")
                        .HasForeignKey("DataFraOpdragsgiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataFraOppdragsgiverPrøverModel");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.DataEtterKuttingOgSlipingModel", b =>
                {
                    b.HasOne("Report_Generator_Domain.Models.DataFraOppdragsgiverPrøverModel", "DataFraOppdragsgiverPrøverModel")
                        .WithMany("DataEtterKuttingOgSlipingModel")
                        .HasForeignKey("DataFraOpdragsgiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataFraOppdragsgiverPrøverModel");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.DataFraOppdragsgiverPrøverModel", b =>
                {
                    b.HasOne("Domain.Models.ReportModel", "ReportModel")
                        .WithMany("DataFraOppdragsgiverPrøver")
                        .HasForeignKey("ReportModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportModel");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.TestModel", b =>
                {
                    b.HasOne("Domain.Models.ReportModel", "ReportModel")
                        .WithMany("Test")
                        .HasForeignKey("ReportModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportModel");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.TrykktestingModel", b =>
                {
                    b.HasOne("Report_Generator_Domain.Models.DataFraOppdragsgiverPrøverModel", "DataFraOppdragsgiverPrøverModel")
                        .WithMany("TrykktestingModel")
                        .HasForeignKey("DataFraOpdragsgiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataFraOppdragsgiverPrøverModel");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.verktøyModel", b =>
                {
                    b.HasOne("Domain.Models.ReportModel", "ReportModel")
                        .WithMany("Verktøy")
                        .HasForeignKey("ReportModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportModel");
                });

            modelBuilder.Entity("Domain.Models.ReportModel", b =>
                {
                    b.Navigation("DataFraOppdragsgiverPrøver");

                    b.Navigation("Images");

                    b.Navigation("Test");

                    b.Navigation("Verktøy");
                });

            modelBuilder.Entity("Report_Generator_Domain.Models.DataFraOppdragsgiverPrøverModel", b =>
                {
                    b.Navigation("ConcreteDensityModel");

                    b.Navigation("DataEtterKuttingOgSlipingModel");

                    b.Navigation("TrykktestingModel");
                });
#pragma warning restore 612, 618
        }
    }
}
