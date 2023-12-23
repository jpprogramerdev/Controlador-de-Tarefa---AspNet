using TodoManager.Models;

namespace TodoManager.Repositories.Interfaces {
    public interface IPrioridadeRepository {
        public IEnumerable<PrioridadeTarefa> SelecionarPrioridades();
        public PrioridadeTarefa SelecionarPrioridaePorId(int id);
    }
}
