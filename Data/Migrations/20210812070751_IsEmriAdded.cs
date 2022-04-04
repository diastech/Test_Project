using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class IsEmriAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnvanterId",
                table: "IsEmris",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OdaId",
                table: "IsEmris",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IsEmris_EnvanterId",
                table: "IsEmris",
                column: "EnvanterId");

            migrationBuilder.CreateIndex(
                name: "IX_IsEmris_OdaId",
                table: "IsEmris",
                column: "OdaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IsEmris_Envanters_EnvanterId",
                table: "IsEmris",
                column: "EnvanterId",
                principalTable: "Envanters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IsEmris_Odas_OdaId",
                table: "IsEmris",
                column: "OdaId",
                principalTable: "Odas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IsEmris_Envanters_EnvanterId",
                table: "IsEmris");

            migrationBuilder.DropForeignKey(
                name: "FK_IsEmris_Odas_OdaId",
                table: "IsEmris");

            migrationBuilder.DropIndex(
                name: "IX_IsEmris_EnvanterId",
                table: "IsEmris");

            migrationBuilder.DropIndex(
                name: "IX_IsEmris_OdaId",
                table: "IsEmris");

            migrationBuilder.DropColumn(
                name: "EnvanterId",
                table: "IsEmris");

            migrationBuilder.DropColumn(
                name: "OdaId",
                table: "IsEmris");
        }
    }
}
