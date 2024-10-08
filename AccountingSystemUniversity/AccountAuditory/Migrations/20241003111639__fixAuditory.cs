using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountAuditory.Migrations
{
    /// <inheritdoc />
    public partial class _fixAuditory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_Buildings_BuildingId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.AlterColumn<int>(
                name: "TypeRoomId",
                schema: "public",
                table: "Auditory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                schema: "public",
                table: "Auditory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_Buildings_BuildingId",
                schema: "public",
                table: "Auditory",
                column: "BuildingId",
                principalSchema: "public",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory",
                column: "TypeRoomId",
                principalSchema: "public",
                principalTable: "TypeRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_Buildings_BuildingId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.DropForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.AlterColumn<int>(
                name: "TypeRoomId",
                schema: "public",
                table: "Auditory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                schema: "public",
                table: "Auditory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_Buildings_BuildingId",
                schema: "public",
                table: "Auditory",
                column: "BuildingId",
                principalSchema: "public",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditory_TypeRoom_TypeRoomId",
                schema: "public",
                table: "Auditory",
                column: "TypeRoomId",
                principalSchema: "public",
                principalTable: "TypeRoom",
                principalColumn: "Id");
        }
    }
}
