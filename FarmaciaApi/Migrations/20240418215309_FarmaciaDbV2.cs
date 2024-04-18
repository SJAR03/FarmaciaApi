using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class FarmaciaDbV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW PresentacionView AS
                                    SELECT 
                                        p.IdPresentacion,
                                        p.Nombre,
                                        p.Descripcion,
                                        p.IdDosificacion,
                                        d.Nombre AS NombreDosificacion,
                                        p.IdMedidas,
                                        m.Nombre AS NombreMedidas
                                    FROM 
                                        Presentaciones p
                                    INNER JOIN 
                                        Dosificaciones d ON p.IdDosificacion = d.IdDosificacion
                                    INNER JOIN 
                                        Medidas m ON p.IdMedidas = m.IdMedidas;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS PresentacionView;");
        }
    }
}
