using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_2020_01_30.Migrations
{
    public partial class UpdateTakmicenjeAddFKSkola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkolaId",
                table: "Takmicenje",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Takmicenje_SkolaId",
                table: "Takmicenje",
                column: "SkolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Takmicenje_Skola_SkolaId",
                table: "Takmicenje",
                column: "SkolaId",
                principalTable: "Skola",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Takmicenje_Skola_SkolaId",
                table: "Takmicenje");

            migrationBuilder.DropIndex(
                name: "IX_Takmicenje_SkolaId",
                table: "Takmicenje");

            migrationBuilder.DropColumn(
                name: "SkolaId",
                table: "Takmicenje");
        }
    }
}
