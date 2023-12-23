using TodoManager.Context;
using TodoManager.Models;
using TodoManager.Repositories.Interfaces;

namespace TodoManager.Repositories {
    public class StatusTarefaRepository :IStatusTarefaRepository {
        private readonly AppDbContext _context;

        public StatusTarefaRepository(AppDbContext context) { 
            _context = context;
        }

        public StatusTarefa SelecionarStatusPorId(int id) => _context.StatusTarefas.Where(st => st.STS_Id == id).FirstOrDefault();
    }
}
