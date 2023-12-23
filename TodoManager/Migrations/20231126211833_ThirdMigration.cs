using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManager.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios'_UsuarioUSU_Id",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios'",
                table: "Usuarios'");

            migrationBuilder.RenameTable(
                name: "Usuarios'",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "USU_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioUSU_Id",
                table: "Tarefas",
                column: "UsuarioUSU_Id",
                principalTable: "Usuarios",
                principalColumn: "USU_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioUSU_Id",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuarios'");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios'",
                table: "Usuarios'",
                column: "USU_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios'_UsuarioUSU_Id",
                table: "Tarefas",
                column: "UsuarioUSU_Id",
                principalTable: "Usuarios'",
                principalColumn: "USU_Id");
        }
    }
}
