using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsp.Migrations
{
    /// <inheritdoc />
    public partial class asdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "riverLake",
                table: "Visitors",
                newName: "riverlake");

            migrationBuilder.RenameColumn(
                name: "averageMonthlyVisitors",
                table: "Visitors",
                newName: "averagemonthlyvisitors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "riverlake",
                table: "Visitors",
                newName: "riverLake");

            migrationBuilder.RenameColumn(
                name: "averagemonthlyvisitors",
                table: "Visitors",
                newName: "averageMonthlyVisitors");
        }
    }
}
