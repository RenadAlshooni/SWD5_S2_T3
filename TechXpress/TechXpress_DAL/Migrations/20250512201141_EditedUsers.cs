using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechXpress_DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_AspNetUsers_UserId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Orders",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                newName: "IX_Orders_OrderID");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Wishlists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "WishlistID",
                table: "Wishlists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WishlistID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_WishlistID",
                table: "Wishlists",
                column: "WishlistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderID",
                table: "Orders",
                column: "OrderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_AspNetUsers_WishlistID",
                table: "Wishlists",
                column: "WishlistID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_AspNetUsers_WishlistID",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_WishlistID",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "WishlistID",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WishlistID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Orders",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderID",
                table: "Orders",
                newName: "IX_Orders_UserId1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Wishlists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId1",
                table: "Orders",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_AspNetUsers_UserId",
                table: "Wishlists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
