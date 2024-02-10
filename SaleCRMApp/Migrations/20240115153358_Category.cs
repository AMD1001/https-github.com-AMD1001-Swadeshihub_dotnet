using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwadeshiApp.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_user_userid",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_user_userid",
                table: "Wishlist");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Wishlist",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlist_userid",
                table: "Wishlist",
                newName: "IX_Wishlist_userId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "user",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "user",
                newName: "PinCode");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user",
                newName: "MobileNo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubCategory",
                newName: "SubCategoryName");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Review",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_userid",
                table: "Review",
                newName: "IX_Review_userId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "SubCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_user_userId",
                table: "Review",
                column: "userId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_user_userId",
                table: "Wishlist",
                column: "userId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_user_userId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_user_userId",
                table: "Wishlist");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Wishlist",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlist_userId",
                table: "Wishlist",
                newName: "IX_Wishlist_userid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "user",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "user",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "MobileNo",
                table: "user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "SubCategoryName",
                table: "SubCategory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Review",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_Review_userId",
                table: "Review",
                newName: "IX_Review_userid");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_user_userid",
                table: "Review",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_user_userid",
                table: "Wishlist",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
