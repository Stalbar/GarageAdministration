using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAdministration.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContributions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Garages_GarageId",
                table: "Contributions");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_GarageId",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "Contributions");

            migrationBuilder.AddColumn<int>(
                name: "ContributionId",
                table: "Garages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_ContributionId",
                table: "Garages",
                column: "ContributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Contributions_ContributionId",
                table: "Garages",
                column: "ContributionId",
                principalTable: "Contributions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Contributions_ContributionId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_ContributionId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "ContributionId",
                table: "Garages");

            migrationBuilder.AddColumn<int>(
                name: "GarageId",
                table: "Contributions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_GarageId",
                table: "Contributions",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Garages_GarageId",
                table: "Contributions",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
