using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_Appointment_System.Migrations
{
    public partial class FieldChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Appointments",
                newName: "Id");
        }
    }
}
