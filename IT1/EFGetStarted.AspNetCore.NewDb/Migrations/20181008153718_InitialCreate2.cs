using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.AspNetCore.NewDb.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acabamento",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acabamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    AcabamentoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.id);
                    table.ForeignKey(
                        name: "FK_Material_Acabamento_AcabamentoId",
                        column: x => x.AcabamentoId,
                        principalTable: "Acabamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_AcabamentoId",
                table: "Material",
                column: "AcabamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Acabamento");
        }
    }
}
