using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountAuditory.Migrations
{
    /// <inheritdoc />
    public partial class _fixConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRoom",
                table: "TypeRoom");

            migrationBuilder.RenameTable(
                name: "TypeRoom",
                newName: "TypeRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRooms",
                table: "TypeRooms",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TypeRooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "лекционное" },
                    { 2, "для практических занятий" },
                    { 3, "спортзал" },
                    { 4, "пр." }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_TypeRooms_TypeRoomId",
                schema: "public",
                table: "Auditory",
                column: "TypeRoomId",
                principalTable: "TypeRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_TypeRooms_TypeRoomId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRooms",
                table: "TypeRooms");

            migrationBuilder.DeleteData(
                table: "TypeRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeRooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "TypeRooms",
                newName: "TypeRoom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRoom",
                table: "TypeRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory",
                column: "TypeRoomId",
                principalTable: "TypeRoom",
                principalColumn: "Id");
        }
    }
}
