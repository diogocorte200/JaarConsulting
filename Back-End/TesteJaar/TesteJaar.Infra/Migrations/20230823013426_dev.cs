using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteJaar.Infra.Migrations
{
    /// <inheritdoc />
    public partial class dev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidato");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "logradouro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_veiculo",
                table: "veiculo");

            migrationBuilder.RenameTable(
                name: "veiculo",
                newName: "veiculos");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "veiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_veiculos",
                table: "veiculos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_veiculos",
                table: "veiculos");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "veiculos");

            migrationBuilder.RenameTable(
                name: "veiculos",
                newName: "veiculo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_veiculo",
                table: "veiculo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "candidato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Legenda = table.Column<int>(type: "int", nullable: false),
                    NomeCandidato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViceCandidato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logotipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "logradouro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logradouro", x => x.Id);
                });
        }
    }
}
