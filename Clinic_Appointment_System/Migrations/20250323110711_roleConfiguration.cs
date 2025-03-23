using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_Appointment_System.Migrations
{
    public partial class roleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-b8e2-6489cb3454ba", "2b2a7758-f9aa-4c82-8c1c-f34f7cb00bec", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-c9e2-6489cb3454ba", "e5438391-e065-4e27-94d3-ac7c710ec86f", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "c308690c-8a1e-4808-b08a-4930bbc61905", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "7a6b802c-ea37-4f51-b5aa-f25af027c4fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-b8e2-6489cb3454ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-c9e2-6489cb3454ba");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "7a6b802c-ea37-4f51-b5aa-f25af027c4fa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-o7e2-6489cb3454ba");
        }
    }
}
