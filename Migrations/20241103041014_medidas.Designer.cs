﻿// <auto-generated />
using System;
using FarmaciaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmaciaApi.Migrations
{
    [DbContext(typeof(FarmaciaDbContext))]
    [Migration("20241103041014_medidas")]
    partial class medidas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmaciaApi.Models.Dosificacion", b =>
                {
                    b.Property<int>("IdDosificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDosificacion"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDosificacion");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

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

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdExpediente");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

                    b.ToTable("Expedientes");
                });

            modelBuilder.Entity("FarmaciaApi.Models.FarmacoPresentacion", b =>
                {
                    b.Property<int>("IdLoteFarmacoDetalles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoteFarmacoDetalles"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLoteFarmaco")
                        .HasColumnType("int");

                    b.Property<int>("IdPresentacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.HasKey("IdLoteFarmacoDetalles");

                    b.HasIndex("IdLoteFarmaco");

                    b.HasIndex("IdPresentacion");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

                    b.ToTable("LoteFarmacoDetalles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.LoteFarmaco", b =>
                {
                    b.Property<int>("IdLoteFarmaco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoteFarmaco"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdLoteFarmaco");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

                    b.ToTable("LoteFarmacos");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Medidas", b =>
                {
                    b.Property<int>("IdMedidas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedidas"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMedidas");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

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

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

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

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Prescripcion", b =>
                {
                    b.Property<int>("IdPrescripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescripcion"));

                    b.Property<string>("Dosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Duracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdExpediente")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.Property<string>("Instrucciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdPrescripcion");

                    b.HasIndex("IdExpediente");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

                    b.ToTable("Prescripciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.PrescripcionDetalle", b =>
                {
                    b.Property<int>("IdPrescripcionDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescripcionDetalle"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFarmacoPresentacion")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescripcion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.HasKey("IdPrescripcionDetalle");

                    b.HasIndex("IdFarmacoPresentacion");

                    b.HasIndex("IdPrescripcion");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

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

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDosificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdMedidas")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPresentacion");

                    b.HasIndex("IdDosificacion");

                    b.HasIndex("IdMedidas");

                    b.HasIndex("IdUsuarioCreacion");

                    b.HasIndex("IdUsuarioModificacion");

                    b.ToTable("Presentaciones");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.Auditoria", b =>
                {
                    b.Property<int>("IdAuditoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAuditoria"));

                    b.Property<string>("Accion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRegistro")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Tabla")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdAuditoria");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Auditorias");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.Permisos", b =>
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

            modelBuilder.Entity("FarmaciaApi.Models.Security.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.RolesPermisos", b =>
                {
                    b.Property<int>("IdRolesPermisos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRolesPermisos"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdPermisos")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdRolesPermisos");

                    b.HasIndex("IdPermisos");

                    b.HasIndex("IdRol");

                    b.ToTable("PermisosRoles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.UsuarioRoles", b =>
                {
                    b.Property<int>("IdUsuarioRoles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuarioRoles"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioRoles");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuarioRoles");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Dosificacion", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Expediente", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Paciente");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.FarmacoPresentacion", b =>
                {
                    b.HasOne("FarmaciaApi.Models.LoteFarmaco", "LoteFarmaco")
                        .WithMany()
                        .HasForeignKey("IdLoteFarmaco")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Presentacion", "Presentacion")
                        .WithMany()
                        .HasForeignKey("IdPresentacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("LoteFarmaco");

                    b.Navigation("Presentacion");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.LoteFarmaco", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Medidas", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Paciente", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Prescripcion", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Expediente", "Expediente")
                        .WithMany()
                        .HasForeignKey("IdExpediente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Expediente");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.PrescripcionDetalle", b =>
                {
                    b.HasOne("FarmaciaApi.Models.FarmacoPresentacion", "FarmacoPresentacion")
                        .WithMany()
                        .HasForeignKey("IdFarmacoPresentacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Prescripcion", "Prescripcion")
                        .WithMany()
                        .HasForeignKey("IdPrescripcion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FarmacoPresentacion");

                    b.Navigation("Prescripcion");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Presentacion", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Dosificacion", "Dosificacion")
                        .WithMany()
                        .HasForeignKey("IdDosificacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Medidas", "Medidas")
                        .WithMany()
                        .HasForeignKey("IdMedidas")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCreacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioModificacion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Dosificacion");

                    b.Navigation("Medidas");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.Auditoria", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.RolesPermisos", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Security.Permisos", "Permisos")
                        .WithMany()
                        .HasForeignKey("IdPermisos")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Permisos");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("FarmaciaApi.Models.Security.UsuarioRoles", b =>
                {
                    b.HasOne("FarmaciaApi.Models.Security.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarmaciaApi.Models.Security.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
