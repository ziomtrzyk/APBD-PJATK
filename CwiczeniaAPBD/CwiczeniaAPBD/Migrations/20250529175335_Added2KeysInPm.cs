using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CwiczeniaAPBD.Migrations
{
    /// <inheritdoc />
    public partial class Added2KeysInPm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription_Medicaments",
                table: "Prescription_Medicaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription_Medicaments",
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicaments_IdPrescription",
                table: "Prescription_Medicaments",
                column: "IdPrescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription_Medicaments",
                table: "Prescription_Medicaments");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicaments_IdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription_Medicaments",
                table: "Prescription_Medicaments",
                column: "IdPrescription");
        }
    }
}
