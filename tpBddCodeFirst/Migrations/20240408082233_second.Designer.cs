﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tpBddCodeFirst;

#nullable disable

namespace tpBddCodeFirst.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240408082233_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tpBddCodeFirst.Classes.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieID"));

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix_Km")
                        .HasColumnType("float");

                    b.HasKey("CategorieID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code_Postal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateNaissance")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Debut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Fin")
                        .HasColumnType("datetime2");

                    b.Property<double>("Nb_Km")
                        .HasColumnType("float");

                    b.Property<int>("VoitureID")
                        .HasColumnType("int");

                    b.HasKey("LocationID");

                    b.HasIndex("ClientID");

                    b.HasIndex("VoitureID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Marque", b =>
                {
                    b.Property<int>("MarqueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarqueID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarqueID");

                    b.ToTable("Marques");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Voiture", b =>
                {
                    b.Property<int>("VoitureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoitureID"));

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<string>("Couleur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Immat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarqueID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoitureID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("MarqueID");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Location", b =>
                {
                    b.HasOne("tpBddCodeFirst.Classes.Client", "Client")
                        .WithMany("Locations")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tpBddCodeFirst.Classes.Voiture", "Voiture")
                        .WithMany("locations")
                        .HasForeignKey("VoitureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Voiture", b =>
                {
                    b.HasOne("tpBddCodeFirst.Classes.Categorie", "Categorie")
                        .WithMany("VoitureList")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tpBddCodeFirst.Classes.Marque", "Marque")
                        .WithMany("Voitures")
                        .HasForeignKey("MarqueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Marque");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Categorie", b =>
                {
                    b.Navigation("VoitureList");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Client", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Marque", b =>
                {
                    b.Navigation("Voitures");
                });

            modelBuilder.Entity("tpBddCodeFirst.Classes.Voiture", b =>
                {
                    b.Navigation("locations");
                });
#pragma warning restore 612, 618
        }
    }
}
