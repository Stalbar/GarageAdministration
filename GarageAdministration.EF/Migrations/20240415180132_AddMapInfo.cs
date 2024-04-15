using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAdministration.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddMapInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Positions_PositionId",
                table: "Garages");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Garages_PositionId",
                table: "Garages");

            migrationBuilder.AddColumn<int>(
                name: "MapInfoId",
                table: "Garages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MapInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Top = table.Column<double>(type: "REAL", nullable: false),
                    Left = table.Column<double>(type: "REAL", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garages_MapInfoId",
                table: "Garages",
                column: "MapInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_MapInfos_MapInfoId",
                table: "Garages",
                column: "MapInfoId",
                principalTable: "MapInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_MapInfos_MapInfoId",
                table: "Garages");

            migrationBuilder.DropTable(
                name: "MapInfos");

            migrationBuilder.DropIndex(
                name: "IX_Garages_MapInfoId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "MapInfoId",
                table: "Garages");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    XPosition = table.Column<double>(type: "REAL", nullable: false),
                    YPosition = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garages_PositionId",
                table: "Garages",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Positions_PositionId",
                table: "Garages",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
