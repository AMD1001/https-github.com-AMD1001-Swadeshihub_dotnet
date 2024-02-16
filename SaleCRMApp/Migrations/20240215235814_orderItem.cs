using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwadeshiApp.Migrations
{
    /// <inheritdoc />
    public partial class orderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "city",
                table: "OrderItem",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "OrderItem",
                newName: "city");
        }
    }
}
