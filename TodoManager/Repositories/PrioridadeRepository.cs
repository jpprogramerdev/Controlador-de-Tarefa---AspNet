using TodoManager.Context;
using TodoManager.Models;
using TodoManager.Repositories.Interfaces;
using System.Linq;

namespace TodoManager.Repositories {
    public class PrioridadeRepository : IPrioridadeRepository{ 
        private readonly AppDbContext _context;

        public PrioridadeRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<PrioridadeTarefa> SelecionarPrioridades() =>
            _context.PrioridadesTarefas;

        public PrioridadeTarefa SelecionarPrioridaePorId(int id) =>
            _context.PrioridadesTarefas.Where(p => p.PRD_Id == id).FirstOrDefault();
    }
}
