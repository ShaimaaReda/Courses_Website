using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courses.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "courses",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courses_TeacherId",
                table: "courses",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_courses_teachers_TeacherId",
                table: "courses",
                column: "TeacherId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_teachers_TeacherId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_TeacherId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "courses");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
