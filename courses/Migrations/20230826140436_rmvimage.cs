using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courses.Migrations
{
    /// <inheritdoc />
    public partial class rmvimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
