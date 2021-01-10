using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Beatrice_Ana.Migrations
{
    public partial class Appointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Patient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Insurance",
                table: "Patient",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Available = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorID",
                table: "Patient",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_DoctorID",
                table: "Patient",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_DoctorID",
                table: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoctorID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Insurance",
                table: "Patient");
        }
    }
}
