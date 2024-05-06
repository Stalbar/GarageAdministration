using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAdministration.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapId",
                table: "Garages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PathToImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garages_MapId",
                table: "Garages",
                column: "MapId");

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

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropIndex(
                name: "IX_Garages_MapId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "Garages");
        }
    }
}
