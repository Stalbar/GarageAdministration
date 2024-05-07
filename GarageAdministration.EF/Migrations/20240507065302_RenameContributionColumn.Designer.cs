﻿// <auto-generated />
using GarageAdministration.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageAdministration.EF.Migrations
{
    [DbContext(typeof(GarageAdministrationDbContext))]
    [Migration("20240507065302_RenameContributionColumn")]
    partial class RenameContributionColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("GarageAdministration.EF.DTOs.ContributionDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ElectricityFee")
                        .HasColumnType("TEXT");

                    b.Property<int>("GarageId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MembershipFee")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GarageId");

                    b.ToTable("Contributions");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.GarageBlockDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapInfoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MapInfoId");

                    b.ToTable("GarageBlock");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.GarageDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.HasIndex("MapInfoId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Garages");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.MapDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PathToImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.MapInfoDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Angle")
                        .HasColumnType("REAL");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<double>("Left")
                        .HasColumnType("REAL");

                    b.Property<double>("Top")
                        .HasColumnType("REAL");

                    b.Property<double>("Width")
                        .HasColumnType("REAL");

                    b.Property<double>("ZIndex")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("MapInfos");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.OwnerDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.ContributionDto", b =>
                {
                    b.HasOne("GarageAdministration.EF.DTOs.GarageDto", "Garage")
                        .WithMany()
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garage");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.GarageBlockDTO", b =>
                {
                    b.HasOne("GarageAdministration.EF.DTOs.MapInfoDto", "MapInfo")
                        .WithMany()
                        .HasForeignKey("MapInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MapInfo");
                });

            modelBuilder.Entity("GarageAdministration.EF.DTOs.GarageDto", b =>
                {
                    b.HasOne("GarageAdministration.EF.DTOs.MapDto", "Map")
                        .WithMany()
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAdministration.EF.DTOs.MapInfoDto", "MapInfo")
                        .WithMany()
                        .HasForeignKey("MapInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAdministration.EF.DTOs.OwnerDto", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");

                    b.Navigation("MapInfo");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
