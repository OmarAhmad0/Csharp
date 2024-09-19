using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class OneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36dbc90e-1604-4015-8552-2a47db1fe793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdad5ee2-54b3-4336-add4-815cf5624f91");

            migrationBuilder.AddColumn<string>(
                name: "AppuserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8de8e1f8-f5c6-4478-8a9a-1d9bb019d675", null, "User", "USER" },
                    { "ace706f9-b2d3-4d06-9a51-530597125935", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppuserId",
                table: "Comments",
                column: "AppuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppuserId",
                table: "Comments",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppuserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppuserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8de8e1f8-f5c6-4478-8a9a-1d9bb019d675");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace706f9-b2d3-4d06-9a51-530597125935");

            migrationBuilder.DropColumn(
                name: "AppuserId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36dbc90e-1604-4015-8552-2a47db1fe793", null, "User", "USER" },
                    { "cdad5ee2-54b3-4336-add4-815cf5624f91", null, "Admin", "ADMIN" }
                });
        }
    }
}
