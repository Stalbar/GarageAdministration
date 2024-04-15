using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAdministration.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_MapInfos_MapInfoId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Garages");

            migrationBuilder.AlterColumn<int>(
                name: "MapInfoId",
                table: "Garages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_MapInfos_MapInfoId",
                table: "Garages",
                column: "MapInfoId",
                principalTable: "MapInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_MapInfos_MapInfoId",
                table: "Garages");

            migrationBuilder.AlterColumn<int>(
                name: "MapInfoId",
                table: "Garages",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Garages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_MapInfos_MapInfoId",
                table: "Garages",
                column: "MapInfoId",
                principalTable: "MapInfos",
                principalColumn: "Id");
        }
    }
}
