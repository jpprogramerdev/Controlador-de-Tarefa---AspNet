using TodoManager.Models;

namespace TodoManager.Repositories.Interfaces {
    public interface ITarefaRepository {
        IEnumerable<Tarefa> SelecionarTarefas();

        public void SalvarTarefa(Tarefa tarefa);

        public Tarefa SelecionarTarefaPorId(int idTarefa);

        public IEnumerable<Tarefa> SelecionarTarefasDoUsuario(int id);

        public IEnumerable<Tarefa> SelecionarTarefasNaoConcluidasDoUsuario(int id);

        public IEnumerable<Tarefa> SelecionarTarefasNaoConcluidas();
        public void AtualizarStatusTarefa(int idStatus, StatusTarefa Status, Tarefa tarefa);

        public void AtualizarParaNaoConcluida(Tarefa tarefa);

        public void ApagarTarefa(int id);

        public void AtualizarTarefa(Tarefa tarefaAtualizada);
    }
}
