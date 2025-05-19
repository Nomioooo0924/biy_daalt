using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hoolsitebiydaalt.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCartAndCartItemshu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Food",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Food");
        }
    }
}
