using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApi.Migrations
{
    /// <inheritdoc />
    public partial class medidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdUsuarioModificacion",
                table: "Dosificaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Dosificaciones_IdUsuarioCreacion",
                table: "Dosificaciones",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Dosificaciones_IdUsuarioModificacion",
                table: "Dosificaciones",
                column: "IdUsuarioModificacion");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioCreacion",
                table: "Dosificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosificaciones_Usuarios_IdUsuarioModificacion",
                table: "Dosificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Dosificaciones_IdUsuarioCreacion",
                table: "Dosificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Dosificaciones_IdUsuarioModificacion",
                table: "Dosificaciones");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuarioModificacion",
                table: "Dosificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
