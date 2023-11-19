using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Databas_Exam.Migrations
{
    /// <inheritdoc />
    public partial class Finished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricingUtitId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricingUtitId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
