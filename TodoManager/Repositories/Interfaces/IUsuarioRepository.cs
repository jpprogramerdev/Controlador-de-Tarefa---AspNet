using TodoManager.Models;

namespace TodoManager.Repositories.Interfaces {
    public interface IUsuarioRepository {
        public Usuario LoginUsuario(LoginModel login);
        void RegistrarUsuario(Usuario usuario);
        public IEnumerable<Usuario> SelecionarUsuarios();
        public Usuario SelecionarUsuarioPorId(int id);
        public void AlterarUsuario(Usuario usuario);
        public void ApagarUsuario(int id);
    }
}
