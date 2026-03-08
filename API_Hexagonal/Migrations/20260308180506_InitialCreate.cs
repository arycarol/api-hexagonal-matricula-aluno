using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Hexagonal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunosTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MateriaTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCancelamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaTable_AlunosTable_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "AlunosTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MateriaTable_ProfessorTable_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "ProfessorTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaTable_AlunoId",
                table: "MateriaTable",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaTable_ProfessorId",
                table: "MateriaTable",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaTable");

            migrationBuilder.DropTable(
                name: "AlunosTable");

            migrationBuilder.DropTable(
                name: "ProfessorTable");
        }
    }
}
