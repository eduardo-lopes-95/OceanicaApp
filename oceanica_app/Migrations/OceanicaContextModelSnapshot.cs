﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using oceanica_app.Data;

#nullable disable

namespace oceanica_app.Migrations
{
    [DbContext(typeof(OceanicaContext))]
    partial class OceanicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("oceanica_app.Models.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("oceanica_app.Models.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VesselId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VesselId");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("oceanica_app.Models.Vessel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BuildAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoFileName")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("oceanica_app.Models.CrewMember", b =>
                {
                    b.HasOne("oceanica_app.Models.Departament", "Departament")
                        .WithMany("Crew")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("oceanica_app.Models.Departament", b =>
                {
                    b.HasOne("oceanica_app.Models.Vessel", "Vessel")
                        .WithMany("Departaments")
                        .HasForeignKey("VesselId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vessel");
                });

            modelBuilder.Entity("oceanica_app.Models.Departament", b =>
                {
                    b.Navigation("Crew");
                });

            modelBuilder.Entity("oceanica_app.Models.Vessel", b =>
                {
                    b.Navigation("Departaments");
                });
#pragma warning restore 612, 618
        }
    }
}
