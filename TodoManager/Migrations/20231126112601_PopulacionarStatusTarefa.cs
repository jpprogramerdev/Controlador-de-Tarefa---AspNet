using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManager.Migrations
{
    /// <inheritdoc />
    public partial class PopulacionarStatusTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "insert into StatusTarefas(STS_Status) values('Atribuida');" +
                "insert into StatusTarefas(STS_Status) values('Em andamento');" +
                "insert into StatusTarefas(STS_Status) values('Concluida');" +
                "insert into StatusTarefas(STS_Status) values('Não concluida');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete StatusTarefas");
        }
    }
}
