﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20221201140517_MariemAljeneVaccinBD")]
    partial class MariemAljeneVaccinBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Domain.CentreVaccination", b =>
                {
                    b.Property<int>("CentreVaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CentreVaccinationId"));

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<int>("NbChaise")
                        .HasColumnType("int");

                    b.Property<int>("NumTelephone")
                        .HasColumnType("int");

                    b.Property<string>("ResponsableCentre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CentreVaccinationId");

                    b.ToTable("CentreVaccination");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Citoyen", b =>
                {
                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroEvax")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("CIN");

                    b.ToTable("Citoyen");
                });

            modelBuilder.Entity("ApplicationCore.Domain.RendezVous", b =>
                {
                    b.Property<string>("CitoyenFK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VaccinFK")
                        .HasColumnType("int");

                    b.Property<string>("CodeInfermiere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateVaccination")
                        .HasColumnType("datetime2");

                    b.Property<int>("NbDoses")
                        .HasColumnType("int");

                    b.HasKey("CitoyenFK", "VaccinFK");

                    b.HasIndex("VaccinFK");

                    b.ToTable("RendezVous");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Vaccin", b =>
                {
                    b.Property<int>("VaccinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccinId"));

                    b.Property<int>("CentreVaccinationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateValidite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<int>("TypeVaccin")
                        .HasColumnType("int");

                    b.HasKey("VaccinId");

                    b.HasIndex("CentreVaccinationId");

                    b.ToTable("vaccins");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Citoyen", b =>
                {
                    b.OwnsOne("ApplicationCore.Domain.Adresse", "Adresse", b1 =>
                        {
                            b1.Property<string>("CitoyenCIN")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int?>("CodePostal")
                                .IsRequired()
                                .HasColumnType("int")
                                .HasColumnName("CodePostal");

                            b1.Property<int?>("Rue")
                                .IsRequired()
                                .HasColumnType("int")
                                .HasColumnName("Rue");

                            b1.Property<string>("Ville")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Ville");

                            b1.HasKey("CitoyenCIN");

                            b1.ToTable("Citoyen");

                            b1.WithOwner()
                                .HasForeignKey("CitoyenCIN");
                        });

                    b.Navigation("Adresse")
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Domain.RendezVous", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Citoyen", "Citoyen")
                        .WithMany("RendezVous")
                        .HasForeignKey("CitoyenFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Domain.Vaccin", "Vaccin")
                        .WithMany("RendezVous")
                        .HasForeignKey("VaccinFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citoyen");

                    b.Navigation("Vaccin");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Vaccin", b =>
                {
                    b.HasOne("ApplicationCore.Domain.CentreVaccination", "CentreVaccination")
                        .WithMany("Vaccins")
                        .HasForeignKey("CentreVaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentreVaccination");
                });

            modelBuilder.Entity("ApplicationCore.Domain.CentreVaccination", b =>
                {
                    b.Navigation("Vaccins");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Citoyen", b =>
                {
                    b.Navigation("RendezVous");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Vaccin", b =>
                {
                    b.Navigation("RendezVous");
                });
#pragma warning restore 612, 618
        }
    }
}
