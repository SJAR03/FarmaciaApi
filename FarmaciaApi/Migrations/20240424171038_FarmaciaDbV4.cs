using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class FarmaciaDbV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[ExpedienteView] AS
                                    SELECT dbo.Expedientes.IdExpediente,
                                    dbo.Pacientes.IdPaciente,
                                    dbo.Pacientes.Nombres,
                                    dbo.Pacientes.Apellidos,
                                    dbo.Pacientes.FechaNacimiento,
                                    dbo.Pacientes.Sexo,
                                    dbo.Pacientes.Direccion,
                                    dbo.Pacientes.Telefono, 
                                    dbo.Pacientes.Correo,
                                    dbo.Expedientes.FechaCreacion,
                                    dbo.Expedientes.Notas
                                FROM dbo.Expedientes 
                                INNER JOIN 
                                    dbo.Pacientes ON dbo.Expedientes.IdPaciente = dbo.Pacientes.IdPaciente;");

            migrationBuilder.Sql(@"CREATE VIEW [dbo].[PrescripcionView] AS 
                                    SELECT dbo.Prescripciones.IdPrescripcion,
                                    dbo.Expedientes.IdExpediente,
                                    dbo.Expedientes.Notas,
                                    dbo.Prescripciones.Fecha,
                                    dbo.Prescripciones.Dosis,
                                    dbo.Prescripciones.Duracion,
                                    dbo.Prescripciones.Instrucciones
                                FROM dbo.Expedientes 
                                INNER JOIN
                                    dbo.Prescripciones ON dbo.Expedientes.IdExpediente = dbo.Prescripciones.IdExpediente;");

            migrationBuilder.Sql(@"CREATE VIEW [dbo].[PrescripcionDetalleView] AS 
                                    SELECT dbo.PrescripcionDetalles.IdPrescripcionDetalle,
                                    dbo.LoteFarmacos.IdLoteFarmaco,
                                    dbo.Prescripciones.IdPrescripcion,
                                    dbo.LoteFarmacos.Nombre,
                                    dbo.LoteFarmacos.Descripcion,
                                    dbo.LoteFarmacos.Concentracion,
                                    dbo.PrescripcionDetalles.Cantidad,
                                    dbo.Prescripciones.Fecha,
                                    dbo.Prescripciones.Dosis,
                                    dbo.Prescripciones.Duracion,
                                    dbo.Prescripciones.Instrucciones
                                FROM dbo.PrescripcionDetalles 
                                INNER JOIN
                                    dbo.LoteFarmacos ON dbo.PrescripcionDetalles.IdLoteFarmaco = dbo.LoteFarmacos.IdLoteFarmaco
                                INNER JOIN
                                    dbo.Prescripciones ON dbo.PrescripcionDetalles.IdPrescripcion = dbo.Prescripciones.IdPrescripcion;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS ExpedienteView;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS PrescripcionView;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS PrescripcionDetalleView;");
        }
    }
}
