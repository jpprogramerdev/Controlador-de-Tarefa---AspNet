using Microsoft.EntityFrameworkCore;
using TodoManager.Models;

namespace TodoManager.Context {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) {
        }

        public DbSet<PrioridadeTarefa> PrioridadesTarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<StatusTarefa> StatusTarefas { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }

    }
}
