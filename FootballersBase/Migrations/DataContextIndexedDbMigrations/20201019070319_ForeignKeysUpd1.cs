using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballersBase.Migrations.DataContextIndexedDbMigrations
{
    public partial class ForeignKeysUpd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Coaches_CoachId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_NationalTeams_Coaches_CoachId",
                table: "NationalTeams");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "NationalTeams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Clubs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Coaches_CoachId",
                table: "Clubs",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NationalTeams_Coaches_CoachId",
                table: "NationalTeams",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Coaches_CoachId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_NationalTeams_Coaches_CoachId",
                table: "NationalTeams");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "NationalTeams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Clubs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Coaches_CoachId",
                table: "Clubs",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NationalTeams_Coaches_CoachId",
                table: "NationalTeams",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
