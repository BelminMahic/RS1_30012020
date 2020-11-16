using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_2020_01_30.Migrations
{
    public partial class UklanjanjeOdjeljenjaIzTakmicenjaDodavanjeRazreda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Takmicenje_Odjeljenje_OdjeljenjeId",
                table: "Takmicenje");

            migrationBuilder.DropIndex(
                name: "IX_Takmicenje_OdjeljenjeId",
                table: "Takmicenje");

            migrationBuilder.RenameColumn(
                name: "OdjeljenjeId",
                table: "Takmicenje",
                newName: "Razred");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Razred",
                table: "Takmicenje",
                newName: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Takmicenje_OdjeljenjeId",
                table: "Takmicenje",
                column: "OdjeljenjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Takmicenje_Odjeljenje_OdjeljenjeId",
                table: "Takmicenje",
                column: "OdjeljenjeId",
                principalTable: "Odjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
