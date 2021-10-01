using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atividade_EFCore.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "guid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(max)", nullable: false),
                    Populacao = table.Column<int>(type: "int", nullable: false),
                    TaxaCriminalidade = table.Column<double>(type: "float", nullable: false),
                    ImpostoSobreProduto = table.Column<double>(type: "float", nullable: false),
                    EstadoCalamidade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CidadeId = table.Column<Guid>(type: "guid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_funcionarios_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_CidadeId",
                table: "funcionarios",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
