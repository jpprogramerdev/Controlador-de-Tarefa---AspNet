using TodoManager.Context;
using TodoManager.Models;
using TodoManager.Repositories.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TodoManager.Repositories {
    public class TarefaRepository: ITarefaRepository {
        private readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context) {
            _context = context;
        }

        public void ApagarTarefa(int id) {
            Tarefa tarefa = SelecionarTarefaPorId(id);
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
        }

        public void AtualizarParaNaoConcluida(Tarefa tarefa) {
            tarefa.TRF_STS_Id = 4;
            tarefa.StatusTarefa = _context.StatusTarefas.FirstOrDefault(s => s.STS_Id == 4);
            _context.SaveChanges();
        }

        public void AtualizarStatusTarefa(int idStatus, StatusTarefa Status, Tarefa tarefa) {
            tarefa.StatusTarefa = Status;
            tarefa.TRF_STS_Id = idStatus;
            tarefa.TRF_DataFInalizada = DateTime.Now;
            _context.SaveChanges();
        }

        public void AtualizarTarefa(Tarefa tarefaAtualizada) { 
            tarefaAtualizada.Usuario = _context.Usuarios.FirstOrDefault(u => u.USU_Id == tarefaAtualizada.TRF_USU_Id);
            tarefaAtualizada.PrioridadeTarefa = _context.PrioridadesTarefas.FirstOrDefault(p => p.PRD_Id == tarefaAtualizada.TRF_PRD_Id);
            tarefaAtualizada.TRF_DataCriada = DateTime.Now;
            tarefaAtualizada.TRF_STS_Id = 1;
            tarefaAtualizada.StatusTarefa = _context.StatusTarefas.FirstOrDefault(s => s.STS_Id == 1);
            _context.Update(tarefaAtualizada);
            _context.SaveChanges();
        }

        public void SalvarTarefa(Tarefa tarefa) {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public Tarefa SelecionarTarefaPorId(int idTarefa) => 
            _context.
            Tarefas.
            Include(p => p.PrioridadeTarefa).
            Include(s => s.StatusTarefa).
            Include(u => u.Usuario).
            FirstOrDefault(t => t.TRF_Id == idTarefa);

        public IEnumerable<Tarefa> SelecionarTarefas() => 
            _context.
            Tarefas.
            Include(u => u.Usuario).
            Include(p => p.PrioridadeTarefa).
            Include(st => st.StatusTarefa);
        

        public IEnumerable<Tarefa> SelecionarTarefasDoUsuario(int id) => 
            _context.
            Tarefas.
            Where(t => t.TRF_USU_Id == id).
            Include(p => p.PrioridadeTarefa).
            Include(st => st.StatusTarefa).
            Include(u => u.Usuario);

        public IEnumerable<Tarefa> SelecionarTarefasNaoConcluidas() =>
             _context.
             Tarefas.
             Where(t => t.TRF_STS_Id != 3).
             Include(p => p.PrioridadeTarefa).
             Include(st => st.StatusTarefa).
             Include(u => u.Usuario);
        

        public IEnumerable<Tarefa> SelecionarTarefasNaoConcluidasDoUsuario(int id) =>
            _context.
            Tarefas.
            Where(t => t.TRF_USU_Id == id && t.TRF_STS_Id != 3).
            Include(p => p.PrioridadeTarefa).
            Include(st => st.StatusTarefa).
            Include(u => u.Usuario);
        
    }
}
