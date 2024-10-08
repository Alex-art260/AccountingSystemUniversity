using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountAuditory.Migrations
{
    /// <inheritdoc />
    public partial class _addedTypeRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Buildings",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Auditory",
                newName: "Auditory",
                newSchema: "public");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "Buildings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Buildings",
                schema: "public",
                newName: "Buildings");

            migrationBuilder.RenameTable(
                name: "Auditory",
                schema: "public",
                newName: "Auditory");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Buildings",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
