using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechXpress_DAL.Migrations
{
    /// <inheritdoc />
    public partial class in4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Carts");
        }
    }
}
