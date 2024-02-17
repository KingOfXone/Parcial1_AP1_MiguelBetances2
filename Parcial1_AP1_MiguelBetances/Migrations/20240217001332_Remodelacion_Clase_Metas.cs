using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial1_AP1_MiguelBetances.Migrations
{
    /// <inheritdoc />
    public partial class Remodelacion_Clase_Metas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Metas");

            migrationBuilder.RenameColumn(
                name: "Persona",
                table: "Metas",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Metas",
                newName: "Persona");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Metas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
