using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class FarmaciaDbV1 : Migration
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosificaciones", x => x.IdDosificacion);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    IdMedidas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.IdMedidas);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermisos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Presentaciones",
                columns: table => new
                {
                    IdPresentacion = table.Column<int>(type: "int", nullable: false),
                    IdMedidas = table.Column<int>(type: "int", nullable: false),
                    IdDosificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentaciones", x => new { x.IdPresentacion, x.IdMedidas, x.IdDosificacion });
                    table.ForeignKey(
                        name: "FK_Presentaciones_Dosificaciones_IdDosificacion",
                        column: x => x.IdDosificacion,
                        principalTable: "Dosificaciones",
                        principalColumn: "IdDosificacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Medidas_IdMedidas",
                        column: x => x.IdMedidas,
                        principalTable: "Medidas",
                        principalColumn: "IdMedidas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    IdExpediente = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => new { x.IdExpediente, x.IdPaciente });
                    table.ForeignKey(
                        name: "FK_Expedientes_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermisosRoles",
                columns: table => new
                {
                    IdPermisos = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdPermisosRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosRoles", x => new { x.IdPermisos, x.IdRol });
                    table.ForeignKey(
                        name: "FK_PermisosRoles_Permisos_IdPermisos",
                        column: x => x.IdPermisos,
                        principalTable: "Permisos",
                        principalColumn: "IdPermisos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisosRoles_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => new { x.IdUsuario, x.IdRol });
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoteFarmacos",
                columns: table => new
                {
                    IdLoteFarmaco = table.Column<int>(type: "int", nullable: false),
                    IdPresentacion = table.Column<int>(type: "int", nullable: false),
                    IdMedidas = table.Column<int>(type: "int", nullable: false),
                    IdDosificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concentracion = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoteFarmacos", x => new { x.IdLoteFarmaco, x.IdPresentacion, x.IdMedidas, x.IdDosificacion });
                    table.ForeignKey(
                        name: "FK_LoteFarmacos_Presentaciones_IdPresentacion_IdMedidas_IdDosificacion",
                        columns: x => new { x.IdPresentacion, x.IdMedidas, x.IdDosificacion },
                        principalTable: "Presentaciones",
                        principalColumns: new[] { "IdPresentacion", "IdMedidas", "IdDosificacion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescripciones",
                columns: table => new
                {
                    IdPrescripcion = table.Column<int>(type: "int", nullable: false),
                    IdExpediente = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescripciones", x => new { x.IdPrescripcion, x.IdExpediente, x.IdPaciente });
                    table.ForeignKey(
                        name: "FK_Prescripciones_Expedientes_IdExpediente_IdPaciente",
                        columns: x => new { x.IdExpediente, x.IdPaciente },
                        principalTable: "Expedientes",
                        principalColumns: new[] { "IdExpediente", "IdPaciente" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescripcionDetalles",
                columns: table => new
                {
                    IdPrescripcionDetalle = table.Column<int>(type: "int", nullable: false),
                    IdLoteFarmaco = table.Column<int>(type: "int", nullable: false),
                    IdPresentacion = table.Column<int>(type: "int", nullable: false),
                    IdMedidas = table.Column<int>(type: "int", nullable: false),
                    IdDosificacion = table.Column<int>(type: "int", nullable: false),
                    IdPrescripcion = table.Column<int>(type: "int", nullable: false),
                    IdExpediente = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescripcionDetalles", x => new { x.IdPrescripcionDetalle, x.IdLoteFarmaco, x.IdPresentacion, x.IdMedidas, x.IdDosificacion, x.IdPrescripcion, x.IdExpediente, x.IdPaciente });
                    table.ForeignKey(
                        name: "FK_PrescripcionDetalles_LoteFarmacos_IdLoteFarmaco_IdPresentacion_IdMedidas_IdDosificacion",
                        columns: x => new { x.IdLoteFarmaco, x.IdPresentacion, x.IdMedidas, x.IdDosificacion },
                        principalTable: "LoteFarmacos",
                        principalColumns: new[] { "IdLoteFarmaco", "IdPresentacion", "IdMedidas", "IdDosificacion" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescripcionDetalles_Prescripciones_IdPrescripcion_IdExpediente_IdPaciente",
                        columns: x => new { x.IdPrescripcion, x.IdExpediente, x.IdPaciente },
                        principalTable: "Prescripciones",
                        principalColumns: new[] { "IdPrescripcion", "IdExpediente", "IdPaciente" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_IdPaciente",
                table: "Expedientes",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_LoteFarmacos_IdPresentacion_IdMedidas_IdDosificacion",
                table: "LoteFarmacos",
                columns: new[] { "IdPresentacion", "IdMedidas", "IdDosificacion" });

            migrationBuilder.CreateIndex(
                name: "IX_PermisosRoles_IdRol",
                table: "PermisosRoles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_PrescripcionDetalles_IdLoteFarmaco_IdPresentacion_IdMedidas_IdDosificacion",
                table: "PrescripcionDetalles",
                columns: new[] { "IdLoteFarmaco", "IdPresentacion", "IdMedidas", "IdDosificacion" });

            migrationBuilder.CreateIndex(
                name: "IX_PrescripcionDetalles_IdPrescripcion_IdExpediente_IdPaciente",
                table: "PrescripcionDetalles",
                columns: new[] { "IdPrescripcion", "IdExpediente", "IdPaciente" });

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_IdExpediente_IdPaciente",
                table: "Prescripciones",
                columns: new[] { "IdExpediente", "IdPaciente" });

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_IdDosificacion",
                table: "Presentaciones",
                column: "IdDosificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_IdMedidas",
                table: "Presentaciones",
                column: "IdMedidas");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_IdRol",
                table: "UsuarioRoles",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisosRoles");

            migrationBuilder.DropTable(
                name: "PrescripcionDetalles");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "LoteFarmacos");

            migrationBuilder.DropTable(
                name: "Prescripciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

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
        }
    }
}
