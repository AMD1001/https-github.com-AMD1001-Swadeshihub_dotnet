using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwadeshiApp.Migrations
{
    /// <inheritdoc />
    public partial class cancelledDateadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledDate",
                table: "OrderItem",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelledDate",
                table: "OrderItem");
        }
    }
}
