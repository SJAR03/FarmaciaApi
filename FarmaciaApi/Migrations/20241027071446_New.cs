using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosificaciones",
                columns: table => new
                {
                    IdDosificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosificaciones", x => x.IdDosificacion);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermisos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.IdPermisos);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(30)", nullable: false),
                    Pwd = table.Column<string>(type: "varchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "PermisosRoles",
                columns: table => new
                {
                    IdRolesPermisos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdPermisos = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosRoles", x => x.IdRolesPermisos);
                    table.ForeignKey(
                        name: "FK_PermisosRoles_Permisos_IdPermisos",
                        column: x => x.IdPermisos,
                        principalTable: "Permisos",
                        principalColumn: "IdPermisos",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermisosRoles_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    IdAuditoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tabla = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdRegistro = table.Column<int>(type: "int", nullable: false),
                    Accion = table.Column<string>(type: "varchar(50)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.IdAuditoria);
                    table.ForeignKey(
                        name: "FK_Auditorias_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoteFarmacos",
                columns: table => new
                {
                    IdLoteFarmaco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoteFarmacos", x => x.IdLoteFarmaco);
                    table.ForeignKey(
                        name: "FK_LoteFarmacos_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoteFarmacos_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    IdMedidas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.IdMedidas);
                    table.ForeignKey(
                        name: "FK_Medidas_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medidas_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    IdUsuarioRoles = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => x.IdUsuarioRoles);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presentaciones",
                columns: table => new
                {
                    IdPresentacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdMedidas = table.Column<int>(type: "int", nullable: false),
                    IdDosificacion = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentaciones", x => x.IdPresentacion);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Dosificaciones_IdDosificacion",
                        column: x => x.IdDosificacion,
                        principalTable: "Dosificaciones",
                        principalColumn: "IdDosificacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Medidas_IdMedidas",
                        column: x => x.IdMedidas,
                        principalTable: "Medidas",
                        principalColumn: "IdMedidas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    IdExpediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notas = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.IdExpediente);
                    table.ForeignKey(
                        name: "FK_Expedientes_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedientes_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedientes_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoteFarmacoDetalles",
                columns: table => new
                {
                    IdLoteFarmacoDetalles = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdLoteFarmaco = table.Column<int>(type: "int", nullable: false),
                    IdPresentacion = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoteFarmacoDetalles", x => x.IdLoteFarmacoDetalles);
                    table.ForeignKey(
                        name: "FK_LoteFarmacoDetalles_LoteFarmacos_IdLoteFarmaco",
                        column: x => x.IdLoteFarmaco,
                        principalTable: "LoteFarmacos",
                        principalColumn: "IdLoteFarmaco",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoteFarmacoDetalles_Presentaciones_IdPresentacion",
                        column: x => x.IdPresentacion,
                        principalTable: "Presentaciones",
                        principalColumn: "IdPresentacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoteFarmacoDetalles_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoteFarmacoDetalles_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescripciones",
                columns: table => new
                {
                    IdPrescripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdExpediente = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescripciones", x => x.IdPrescripcion);
                    table.ForeignKey(
                        name: "FK_Prescripciones_Expedientes_IdExpediente",
                        column: x => x.IdExpediente,
                        principalTable: "Expedientes",
                        principalColumn: "IdExpediente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescripciones_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescripciones_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescripcionDetalles",
                columns: table => new
                {
                    IdPrescripcionDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdPrescripcion = table.Column<int>(type: "int", nullable: false),
                    IdFarmacoPresentacion = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescripcionDetalles", x => x.IdPrescripcionDetalle);
                    table.ForeignKey(
                        name: "FK_PrescripcionDetalles_LoteFarmacoDetalles_IdFarmacoPresentacion",
                        column: x => x.IdFarmacoPresentacion,
                        principalTable: "LoteFarmacoDetalles",
                        principalColumn: "IdLoteFarmacoDetalles",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescripcionDetalles_Prescripciones_IdPrescripcion",
                        column: x => x.IdPrescripcion,
                        principalTable: "Prescripciones",
                        principalColumn: "IdPrescripcion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescripcionDetalles_Usuarios_IdUsuarioCreacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescripcionDetalles_Usuarios_IdUsuarioModificacion",
                        column: x => x.IdUsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_IdUsuario",
                table: "Auditorias",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_IdPaciente",
                table: "Expedientes",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_IdUsuarioCreacion",
                table: "Expedientes",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_IdUsuarioModificacion",
                table: "Expedientes",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_LoteFarmacoDetalles_IdLoteFarmaco",
                table: "LoteFarmacoDetalles",
                column: "IdLoteFarmaco");

            migrationBuilder.CreateIndex(
                name: "IX_LoteFarmacoDetalles_IdPresentacion",
                table: "LoteFarmacoDetalles",
                column: "IdPresentacion");

            migrationBuilder.CreateIndex(
                name: "IX_LoteFarmacoDetalles_IdUsuarioCreacion",
                table: "LoteFarmacoDetalles",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_LoteFarmacoDetalles_IdUsuarioModificacion",
                table: "LoteFarmacoDetalles",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_LoteFarmacos_IdUsuarioCreacion",
                table: "LoteFarmacos",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_LoteFarmacos_IdUsuarioModificacion",
                table: "LoteFarmacos",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Medidas_IdUsuarioCreacion",
                table: "Medidas",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Medidas_IdUsuarioModificacion",
                table: "Medidas",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuarioCreacion",
                table: "Pacientes",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuarioModificacion",
                table: "Pacientes",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosRoles_IdPermisos",
                table: "PermisosRoles",
                column: "IdPermisos");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosRoles_IdRol",
                table: "PermisosRoles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_PrescripcionDetalles_IdFarmacoPresentacion",
                table: "PrescripcionDetalles",
                column: "IdFarmacoPresentacion");

            migrationBuilder.CreateIndex(
                name: "IX_PrescripcionDetalles_IdPrescripcion",
                table: "PrescripcionDetalles",
                column: "IdPrescripcion");

            migrationBuilder.CreateIndex(
                name: "IX_PrescripcionDetalles_IdUsuarioCreacion",
                table: "PrescripcionDetalles",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_PrescripcionDetalles_IdUsuarioModificacion",
                table: "PrescripcionDetalles",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_IdExpediente",
                table: "Prescripciones",
                column: "IdExpediente");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_IdUsuarioCreacion",
                table: "Prescripciones",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_IdUsuarioModificacion",
                table: "Prescripciones",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_IdDosificacion",
                table: "Presentaciones",
                column: "IdDosificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_IdMedidas",
                table: "Presentaciones",
                column: "IdMedidas");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_IdUsuarioCreacion",
                table: "Presentaciones",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_IdUsuarioModificacion",
                table: "Presentaciones",
                column: "IdUsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_IdRol",
                table: "UsuarioRoles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_IdUsuario",
                table: "UsuarioRoles",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "PermisosRoles");

            migrationBuilder.DropTable(
                name: "PrescripcionDetalles");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "LoteFarmacoDetalles");

            migrationBuilder.DropTable(
                name: "Prescripciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "LoteFarmacos");

            migrationBuilder.DropTable(
                name: "Presentaciones");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "Dosificaciones");

            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
