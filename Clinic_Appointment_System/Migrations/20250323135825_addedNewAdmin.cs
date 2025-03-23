using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_Appointment_System.Migrations
{
    public partial class addedNewAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "7a6b802c-ea37-4f51-b5aa-f25af027c4fa" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-b8e2-6489cb3454ba",
                column: "ConcurrencyStamp",
                value: "92a480bd-d293-4d93-8584-e8ac1a462e87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-c9e2-6489cb3454ba",
                column: "ConcurrencyStamp",
                value: "dd88d9a0-027a-44af-9e97-e012af8bd59e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-o7e2-6489cb3454ba",
                column: "ConcurrencyStamp",
                value: "6aaa8c6f-bbc5-4133-91e8-48d620e1222f");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "3d31173d-9396-46aa-999a-49a59c46d3ad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "3d31173d-9396-46aa-999a-49a59c46d3ad" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-b8e2-6489cb3454ba",
                column: "ConcurrencyStamp",
                value: "2b2a7758-f9aa-4c82-8c1c-f34f7cb00bec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-c9e2-6489cb3454ba",
                column: "ConcurrencyStamp",
                value: "e5438391-e065-4e27-94d3-ac7c710ec86f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-o7e2-6489cb3454ba",
                column: "ConcurrencyStamp",
                value: "c308690c-8a1e-4808-b08a-4930bbc61905");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "7a6b802c-ea37-4f51-b5aa-f25af027c4fa" });
        }
    }
}
