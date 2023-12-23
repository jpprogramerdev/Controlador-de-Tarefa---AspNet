using TodoManager.Models;

namespace TodoManager.Repositories.Interfaces {
    public interface IStatusTarefaRepository {
        public StatusTarefa SelecionarStatusPorId(int id);
    }
}
