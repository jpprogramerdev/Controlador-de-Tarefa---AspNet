using TodoManager.Models;

namespace TodoManager.ViewModel {
    public class UsuarioTarefa {
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<PrioridadeTarefa> Prioridades { get; set; }
        public Tarefa Tarefa { get; set; }

        //utlizado para identificar qual pagina de layout aplicar nas pagina de tarefa
        public Usuario Usuario { get; set; }
    }
}
