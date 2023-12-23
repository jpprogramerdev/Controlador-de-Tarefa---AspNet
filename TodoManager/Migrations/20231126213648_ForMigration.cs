using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManager.Migrations
{
    /// <inheritdoc />
    public partial class ForMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioTPU_Id",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "USU_TPU_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    TPU_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TPU_Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.TPU_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioTPU_Id",
                table: "Usuarios",
                column: "TipoUsuarioTPU_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TiposUsuarios_TipoUsuarioTPU_Id",
                table: "Usuarios",
                column: "TipoUsuarioTPU_Id",
                principalTable: "TiposUsuarios",
                principalColumn: "TPU_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TiposUsuarios_TipoUsuarioTPU_Id",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoUsuarioTPU_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioTPU_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "USU_TPU_Id",
                table: "Usuarios");
        }
    }
}
