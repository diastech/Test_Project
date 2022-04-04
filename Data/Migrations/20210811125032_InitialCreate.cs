using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Binas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SilindiMi = table.Column<bool>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    Numara = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Envanters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SilindiMi = table.Column<bool>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    Numara = table.Column<int>(nullable: false),
                    Durum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envanters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IsEmris",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SilindiMi = table.Column<bool>(nullable: false),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsEmris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Odas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SilindiMi = table.Column<bool>(nullable: false),
                    Numara = table.Column<int>(nullable: false),
                    BinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Odas_Binas_BinaID",
                        column: x => x.BinaID,
                        principalTable: "Binas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Depos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SilindiMi = table.Column<bool>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    EnvanterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Depos_Envanters_EnvanterID",
                        column: x => x.EnvanterID,
                        principalTable: "Envanters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UrunYolus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SilindiMi = table.Column<bool>(nullable: false),
                    OdaId = table.Column<int>(nullable: false),
                    EnvanterId = table.Column<int>(nullable: false),
                    BinaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunYolus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UrunYolus_Binas_BinaID",
                        column: x => x.BinaID,
                        principalTable: "Binas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UrunYolus_Envanters_EnvanterId",
                        column: x => x.EnvanterId,
                        principalTable: "Envanters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunYolus_Odas_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Odas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depos_EnvanterID",
                table: "Depos",
                column: "EnvanterID");

            migrationBuilder.CreateIndex(
                name: "IX_Odas_BinaID",
                table: "Odas",
                column: "BinaID");

            migrationBuilder.CreateIndex(
                name: "IX_UrunYolus_BinaID",
                table: "UrunYolus",
                column: "BinaID");

            migrationBuilder.CreateIndex(
                name: "IX_UrunYolus_EnvanterId",
                table: "UrunYolus",
                column: "EnvanterId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunYolus_OdaId",
                table: "UrunYolus",
                column: "OdaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depos");

            migrationBuilder.DropTable(
                name: "IsEmris");

            migrationBuilder.DropTable(
                name: "UrunYolus");

            migrationBuilder.DropTable(
                name: "Envanters");

            migrationBuilder.DropTable(
                name: "Odas");

            migrationBuilder.DropTable(
                name: "Binas");
        }
    }
}
