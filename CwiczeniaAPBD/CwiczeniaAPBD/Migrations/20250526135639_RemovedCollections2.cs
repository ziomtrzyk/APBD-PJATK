using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CwiczeniaAPBD.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCollections2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicaments_Medicaments_IdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicaments_IdMedicament",
                table: "Prescription_Medicaments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicaments_IdMedicament",
                table: "Prescription_Medicaments",
                column: "IdMedicament");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicaments_Medicaments_IdMedicament",
                table: "Prescription_Medicaments",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
