using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hoolsitebiydaalt.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCartAndCartItemTabless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Food");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Food",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
