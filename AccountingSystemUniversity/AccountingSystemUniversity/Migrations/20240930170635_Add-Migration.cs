using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingSystemUniversity.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                schema: "public",
                table: "Building",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                schema: "public",
                table: "Building");

            migrationBuilder.RenameTable(
                name: "Building",
                schema: "public",
                newName: "Buildings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");
        }
    }
}
