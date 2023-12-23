using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManager.Migrations
{
    /// <inheritdoc />
    public partial class PopulacionarPrioridadeTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                "Insert into PrioridadesTarefas(PRD_Descricao) values('Baixa');" +
                "Insert into PrioridadesTarefas(PRD_Descricao) values('Média');" +
                "Insert into PrioridadesTarefas(PRD_Descricao) values('Alta');"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete PrioridadesTarefas");
        }
    }
}
