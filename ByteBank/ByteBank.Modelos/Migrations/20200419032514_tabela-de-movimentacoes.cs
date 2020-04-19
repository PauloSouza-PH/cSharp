using Microsoft.EntityFrameworkCore.Migrations;

namespace ByteBank.Modelos.Migrations
{
    public partial class tabelademovimentacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    MovimentosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: true),
                    ContaCorrenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.MovimentosId);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_ContaCorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ContaCorrenteId",
                table: "Movimentacoes",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");
        }
    }
}
