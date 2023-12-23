using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManager.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusTarefaSTS_Id",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TRF_STS_Id",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusTarefas",
                columns: table => new
                {
                    STS_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STS_Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTarefas", x => x.STS_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_StatusTarefaSTS_Id",
                table: "Tarefas",
                column: "StatusTarefaSTS_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_StatusTarefas_StatusTarefaSTS_Id",
                table: "Tarefas",
                column: "StatusTarefaSTS_Id",
                principalTable: "StatusTarefas",
                principalColumn: "STS_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_StatusTarefas_StatusTarefaSTS_Id",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "StatusTarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_StatusTarefaSTS_Id",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "StatusTarefaSTS_Id",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "TRF_STS_Id",
                table: "Tarefas");
        }
    }
}
