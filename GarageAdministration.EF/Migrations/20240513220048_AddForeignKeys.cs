using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAdministration.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Maps_MapId",
                table: "Garages");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Garages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Maps_MapId",
                table: "Garages",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Maps_MapId",
                table: "Garages");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Garages",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Maps_MapId",
                table: "Garages",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id");
        }
    }
}
