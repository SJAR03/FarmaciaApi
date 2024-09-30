using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class modelFixFarmaco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescripcionDetalles_LoteFarmacos_IdLoteFarmaco",
                table: "PrescripcionDetalles");

            migrationBuilder.DropTable(
                name: "ExpedienteView");

            migrationBuilder.DropTable(
                name: "LoteFarmacosView");

            migrationBuilder.DropTable(
                name: "PrescripcionDetalleView");

            migrationBuilder.DropTable(
                name: "PrescripcionView");

            migrationBuilder.DropTable(
                name: "PresentacionView");

            migrationBuilder.RenameColumn(
                name: "IdLoteFarmaco",
                table: "PrescripcionDetalles",
                newName: "IdFarmacoPresentacion");

            migrationBuilder.RenameIndex(
                name: "IX_PrescripcionDetalles_IdLoteFarmaco",
                table: "PrescripcionDetalles",
                newName: "IX_PrescripcionDetalles_IdFarmacoPresentacion");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescripcionDetalles_LoteFarmacoDetalles_IdFarmacoPresentacion",
                table: "PrescripcionDetalles",
                column: "IdFarmacoPresentacion",
                principalTable: "LoteFarmacoDetalles",
                principalColumn: "IdLoteFarmacoDetalles",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescripcionDetalles_LoteFarmacoDetalles_IdFarmacoPresentacion",
                table: "PrescripcionDetalles");

            migrationBuilder.RenameColumn(
                name: "IdFarmacoPresentacion",
                table: "PrescripcionDetalles",
                newName: "IdLoteFarmaco");

            migrationBuilder.RenameIndex(
                name: "IX_PrescripcionDetalles_IdFarmacoPresentacion",
                table: "PrescripcionDetalles",
                newName: "IX_PrescripcionDetalles_IdLoteFarmaco");

            migrationBuilder.CreateTable(
                name: "ExpedienteView",
                columns: table => new
                {
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdExpediente = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LoteFarmacosView",
                columns: table => new
                {
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Concentracion = table.Column<int>(type: "int", nullable: false),
                    DescripcionLoteFarmaco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionPresentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDosificacion = table.Column<int>(type: "int", nullable: false),
                    IdLoteFarmaco = table.Column<int>(type: "int", nullable: false),
                    IdMedidas = table.Column<int>(type: "int", nullable: false),
                    IdPresentacion = table.Column<int>(type: "int", nullable: false),
                    NombreDosificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreLoteFarmaco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreMedidas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombrePresentacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PrescripcionDetalleView",
                columns: table => new
                {
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Concentracion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLoteFarmaco = table.Column<int>(type: "int", nullable: false),
                    IdPrescripcion = table.Column<int>(type: "int", nullable: false),
                    IdPrescripcionDetalle = table.Column<int>(type: "int", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PrescripcionView",
                columns: table => new
                {
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdExpediente = table.Column<int>(type: "int", nullable: false),
                    IdPrescripcion = table.Column<int>(type: "int", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PresentacionView",
                columns: table => new
                {
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDosificacion = table.Column<int>(type: "int", nullable: false),
                    IdMedidas = table.Column<int>(type: "int", nullable: false),
                    IdPresentacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreDosificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreMedidas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PrescripcionDetalles_LoteFarmacos_IdLoteFarmaco",
                table: "PrescripcionDetalles",
                column: "IdLoteFarmaco",
                principalTable: "LoteFarmacos",
                principalColumn: "IdLoteFarmaco",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
