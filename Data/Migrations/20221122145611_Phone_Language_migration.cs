using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Phone_Language_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_EmergencyShelters_EmergencyShelterID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Poles_EmergencyShelters_EmergencyShelterID",
                table: "Poles");

            migrationBuilder.RenameColumn(
                name: "EmergencyShelterID",
                table: "Poles",
                newName: "EmergencyShelterId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Poles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Poles_EmergencyShelterID",
                table: "Poles",
                newName: "IX_Poles_EmergencyShelterId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "EmergencyShelters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmergencyShelterID",
                table: "Customers",
                newName: "EmergencyShelterId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_EmergencyShelterID",
                table: "Customers",
                newName: "IX_Customers_EmergencyShelterId");

            migrationBuilder.AddColumn<string>(
                name: "LanguagesSpoken",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_EmergencyShelters_EmergencyShelterId",
                table: "Customers",
                column: "EmergencyShelterId",
                principalTable: "EmergencyShelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poles_EmergencyShelters_EmergencyShelterId",
                table: "Poles",
                column: "EmergencyShelterId",
                principalTable: "EmergencyShelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_EmergencyShelters_EmergencyShelterId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Poles_EmergencyShelters_EmergencyShelterId",
                table: "Poles");

            migrationBuilder.DropColumn(
                name: "LanguagesSpoken",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "EmergencyShelterId",
                table: "Poles",
                newName: "EmergencyShelterID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Poles",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Poles_EmergencyShelterId",
                table: "Poles",
                newName: "IX_Poles_EmergencyShelterID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmergencyShelters",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "EmergencyShelterId",
                table: "Customers",
                newName: "EmergencyShelterID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_EmergencyShelterId",
                table: "Customers",
                newName: "IX_Customers_EmergencyShelterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_EmergencyShelters_EmergencyShelterID",
                table: "Customers",
                column: "EmergencyShelterID",
                principalTable: "EmergencyShelters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poles_EmergencyShelters_EmergencyShelterID",
                table: "Poles",
                column: "EmergencyShelterID",
                principalTable: "EmergencyShelters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
