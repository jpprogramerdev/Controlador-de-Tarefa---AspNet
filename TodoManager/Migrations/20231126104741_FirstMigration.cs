using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManager.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrioridadesTarefas",
                columns: table => new
                {
                    PRD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRD_Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioridadesTarefas", x => x.PRD_Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios'",
                columns: table => new
                {
                    USU_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USU_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USU_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USU_Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios'", x => x.USU_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TRF_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRF_Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRF_Descrição = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRF_DataCriada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRF_DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRF_PRD_Id = table.Column<int>(type: "int", nullable: false),
                    PrioridadeTarefaPRD_Id = table.Column<int>(type: "int", nullable: true),
                    TRF_USU_Id = table.Column<int>(type: "int", nullable: false),
                    UsuarioUSU_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TRF_Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_PrioridadesTarefas_PrioridadeTarefaPRD_Id",
                        column: x => x.PrioridadeTarefaPRD_Id,
                        principalTable: "PrioridadesTarefas",
                        principalColumn: "PRD_Id");
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios'_UsuarioUSU_Id",
                        column: x => x.UsuarioUSU_Id,
                        principalTable: "Usuarios'",
                        principalColumn: "USU_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_PrioridadeTarefaPRD_Id",
                table: "Tarefas",
                column: "PrioridadeTarefaPRD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioUSU_Id",
                table: "Tarefas",
                column: "UsuarioUSU_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "PrioridadesTarefas");

            migrationBuilder.DropTable(
                name: "Usuarios'");
        }
    }
}
