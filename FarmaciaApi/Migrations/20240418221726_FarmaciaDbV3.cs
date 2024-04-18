using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class FarmaciaDbV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW LoteFarmacosView AS
                                    SELECT 
                                        lf.IdLoteFarmaco,
                                        lf.Nombre AS NombreLoteFarmaco,
                                        lf.Descripcion AS DescripcionLoteFarmaco,
                                        lf.Concentracion,
                                        lf.Cantidad,
                                        p.IdPresentacion,
                                        p.Nombre AS NombrePresentacion,
                                        p.Descripcion AS DescripcionPresentacion,
                                        m.IdMedidas,
                                        m.Nombre AS NombreMedidas,
                                        d.IdDosificacion,
                                        d.Nombre AS NombreDosificacion
                                    FROM 
                                        LoteFarmacos lf
                                    INNER JOIN 
                                        Presentaciones p ON lf.IdLoteFarmaco = p.IdPresentacion
                                    INNER JOIN 
                                        Dosificaciones d ON p.IdDosificacion = d.IdDosificacion
                                    INNER JOIN 
                                        Medidas m ON p.IdMedidas = m.IdMedidas;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS LoteFarmacosView;");
        }
    }
}
