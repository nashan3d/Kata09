using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kata09.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateRangeForDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicableDateEnd",
                table: "PriceRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicableDateStart",
                table: "PriceRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicableDateEnd",
                table: "PriceRules");

            migrationBuilder.DropColumn(
                name: "ApplicableDateStart",
                table: "PriceRules");
        }
    }
}
