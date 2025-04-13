using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoilerPlate.Identity.Migrations
{
    /// <inheritdoc />
    public partial class refreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6087 - 1ebe - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2b55ca2-05ae-428e-88a0-4bdc2140c0d4", "AQAAAAIAAYagAAAAEHqXxmPeJkb2Ro6YXD1Y9gtOdK4dm2oAPIQNRBRf+tqUdqG4GH0TAMkaTDRpKZ/8CA==", "89bff68e-10cf-4123-b3e3-10aa97abe15e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6087 - 1rbr - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48d85413-cb42-49b5-b909-4ad1e9983a05", "AQAAAAIAAYagAAAAEOucoTcD/KjZRHcRTuVNJqbnDd2Kx8zsiaSazD+Blx/fSD+UMv6eEZfEzsJzgVjEhA==", "ec658a14-c0ef-489a-bec4-840c6a7b6c5e" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6087 - 1ebe - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da90d526-9286-46cf-849d-cb8cf1654cad", "AQAAAAIAAYagAAAAEI5joAsxGPm7IEnHHrdBhXtYiAYp7D5JzqhX34aU/EQm1in26FEE2akauQzMA/rRnw==", "083e2023-82ca-42d4-8f75-cf14a67c9b6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6087 - 1rbr - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61d78598-cae8-4a05-b4a7-a689b7543565", "AQAAAAIAAYagAAAAEObG/xbupd3ax8O7+28Q8f7qO+Ki3TD3yKM+XQWEgeKwSow4m8dScd1GfXopKmJetw==", "5e740504-73f8-4cc7-8426-fe0a1068c460" });
        }
    }
}
