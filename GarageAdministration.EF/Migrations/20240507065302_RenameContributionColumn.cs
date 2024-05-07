using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAdministration.EF.Migrations
{
    /// <inheritdoc />
    public partial class RenameContributionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WaterFee",
                table: "Contributions",
                newName: "ElectricityFee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectricityFee",
                table: "Contributions",
                newName: "WaterFee");
        }
    }
}
