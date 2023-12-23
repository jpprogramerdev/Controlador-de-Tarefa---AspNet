using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManager.Migrations
{
    /// <inheritdoc />
    public partial class PopulacionarTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into TiposUsuarios(TPU_Descricao) values ('Administrador');" +
                "insert into TiposUsuarios(TPU_Descricao) values ('Usuarios');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete TiposUsuarios");
        }
    }
}
