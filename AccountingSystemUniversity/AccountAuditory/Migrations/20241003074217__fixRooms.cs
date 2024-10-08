using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountAuditory.Migrations
{
    /// <inheritdoc />
    public partial class _fixRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_TypeRooms_TypeRoomId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRooms",
                table: "TypeRooms");

            migrationBuilder.RenameTable(
                name: "TypeRooms",
                newName: "TypeRoom",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRoom",
                schema: "public",
                table: "TypeRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory",
                column: "TypeRoomId",
                principalSchema: "public",
                principalTable: "TypeRoom",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRoom",
                schema: "public",
                table: "TypeRoom");

            migrationBuilder.RenameTable(
                name: "TypeRoom",
                schema: "public",
                newName: "TypeRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRooms",
                table: "TypeRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_TypeRooms_TypeRoomId",
                schema: "public",
                table: "Auditory",
                column: "TypeRoomId",
                principalTable: "TypeRooms",
                principalColumn: "Id");
        }
    }
}
