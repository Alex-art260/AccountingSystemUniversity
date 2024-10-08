using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountAuditory.Migrations
{
    /// <inheritdoc />
    public partial class _fixAuditory3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Auditory_BuildingId",
                schema: "public",
                table: "Auditory",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditory_TypeRoomId",
                schema: "public",
                table: "Auditory",
                column: "TypeRoomId");

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

            migrationBuilder.DropIndex(
                name: "IX_Auditory_BuildingId",
                schema: "public",
                table: "Auditory");

            migrationBuilder.DropIndex(
                name: "IX_Auditory_TypeRoomId",
                schema: "public",
                table: "Auditory");
        }
    }
}
