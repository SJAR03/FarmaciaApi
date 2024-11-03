using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class dosificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioCreacion",
                table: "Dosificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioModificacion",
                table: "Dosificaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioCreacion",
                table: "Dosificaciones",
                column: "IdUsuarioCreacion",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioModificacion",
                table: "Dosificaciones",
                column: "IdUsuarioModificacion",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioCreacion",
                table: "Dosificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioModificacion",
                table: "Dosificaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioCreacion",
                table: "Dosificaciones",
                column: "IdUsuarioCreacion",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioModificacion",
                table: "Dosificaciones",
                column: "IdUsuarioModificacion",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
