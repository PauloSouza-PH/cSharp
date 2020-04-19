using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ByteBank.Modelos.Migrations
{
    public partial class tabelainicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Cgc = table.Column<string>(nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContadorSaquesNaoPermitidos = table.Column<int>(nullable: false),
                    ContadorTransferenciasNaoPermitidas = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Agencia = table.Column<int>(nullable: false),
                    Saldo = table.Column<double>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaCorrente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_ClienteId",
                table: "ContaCorrente",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaCorrente");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
