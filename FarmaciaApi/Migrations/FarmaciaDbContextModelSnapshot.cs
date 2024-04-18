﻿// <auto-generated />
using System;
using FarmaciaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmaciaApi.Migrations
{
    [DbContext(typeof(FarmaciaDbContext))]
    partial class FarmaciaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmaciaApi.Models.Dosificacion", b =>
                {
                    b.Property<int>("IdDosificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDosificacion"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDosificacion");

                    b.ToTable("Dosificaciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Expediente", b =>
                {
                    b.Property<int>("IdExpediente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExpediente"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdExpediente");

                    b.HasIndex("IdPaciente")
                        .IsUnique();

                    b.ToTable("Expedientes");
                });

            modelBuilder.Entity("FarmaciaApi.Models.LoteFarmaco", b =>
                {
                    b.Property<int>("IdLoteFarmaco")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Concentracion")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IdPresentacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdLoteFarmaco");

                    b.ToTable("LoteFarmacos");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Medidas", b =>
                {
                    b.Property<int>("IdMedidas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedidas"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMedidas");

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdPaciente");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Permisos", b =>
                {
                    b.Property<int>("IdPermisos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermisos"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPermisos");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("FarmaciaApi.Models.PermisosRol", b =>
                {
                    b.Property<int>("IdPermisosRol")
                        .HasColumnType("int");

                    b.Property<int>("IdPermisos")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdPermisosRol");

                    b.ToTable("PermisosRoles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Prescripcion", b =>
                {
                    b.Property<int>("IdPrescripcion")
                        .HasColumnType("int");

                    b.Property<string>("Dosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Duracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdExpediente")
                        .HasColumnType("int");

                    b.Property<string>("Instrucciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdPrescripcion");

                    b.ToTable("Prescripciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.PrescripcionDetalle", b =>
                {
                    b.Property<int>("IdPrescripcionDetalle")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdLoteFarmaco")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescripcion")
                        .HasColumnType("int");

                    b.HasKey("IdPrescripcionDetalle");

                    b.ToTable("PrescripcionDetalles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Presentacion", b =>
                {
                    b.Property<int>("IdPresentacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPresentacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IdDosificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdMedidas")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPresentacion");

                    b.HasIndex("IdDosificacion");

                    b.HasIndex("IdMedidas");

                    b.ToTable("Presentaciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FarmaciaApi.Models.UsuarioRol", b =>
                {
                    b.Property<int>("IdUsuarioRol")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioRol");

                    b.ToTable("UsuarioRoles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Expediente", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Paciente", "Paciente")
                        .WithOne("Expediente")
                        .HasForeignKey("FarmaciaApi.Models.Expediente", "IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("FarmaciaApi.Models.LoteFarmaco", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Presentacion", "Presentacion")
                        .WithMany("LoteFarmacos")
                        .HasForeignKey("IdLoteFarmaco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Presentacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.PermisosRol", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Permisos", "Permisos")
                        .WithMany("PermisosRols")
                        .HasForeignKey("IdPermisosRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Rol", "Rol")
                        .WithMany("permisosRols")
                        .HasForeignKey("IdPermisosRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permisos");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Prescripcion", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Expediente", "Expediente")
                        .WithMany("Prescripciones")
                        .HasForeignKey("IdPrescripcion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expediente");
                });

            modelBuilder.Entity("FarmaciaApi.Models.PrescripcionDetalle", b =>
                {
                    b.HasOne("FarmaciaApi.Models.LoteFarmaco", "LoteFarmaco")
                        .WithMany("PrescripcionDetalles")
                        .HasForeignKey("IdPrescripcionDetalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Prescripcion", "Prescripcion")
                        .WithMany("PrescripcionDetalles")
                        .HasForeignKey("IdPrescripcionDetalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoteFarmaco");

                    b.Navigation("Prescripcion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Presentacion", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Dosificacion", "Dosificacion")
                        .WithMany("Presentaciones")
                        .HasForeignKey("IdDosificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Medidas", "Medidas")
                        .WithMany("Presentaciones")
                        .HasForeignKey("IdMedidas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dosificacion");

                    b.Navigation("Medidas");
                });

            modelBuilder.Entity("FarmaciaApi.Models.UsuarioRol", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Rol", "Rol")
                        .WithMany("UsuarioRols")
                        .HasForeignKey("IdUsuarioRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Usuario", "Usuario")
                        .WithMany("UsuarioRols")
                        .HasForeignKey("IdUsuarioRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Dosificacion", b =>
                {
                    b.Navigation("Presentaciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Expediente", b =>
                {
                    b.Navigation("Prescripciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.LoteFarmaco", b =>
                {
                    b.Navigation("PrescripcionDetalles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Medidas", b =>
                {
                    b.Navigation("Presentaciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Paciente", b =>
                {
                    b.Navigation("Expediente")
                        .IsRequired();
                });

            modelBuilder.Entity("FarmaciaApi.Models.Permisos", b =>
                {
                    b.Navigation("PermisosRols");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Prescripcion", b =>
                {
                    b.Navigation("PrescripcionDetalles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Presentacion", b =>
                {
                    b.Navigation("LoteFarmacos");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Rol", b =>
                {
                    b.Navigation("UsuarioRols");

                    b.Navigation("permisosRols");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Usuario", b =>
                {
                    b.Navigation("UsuarioRols");
                });
#pragma warning restore 612, 618
        }
    }
}
