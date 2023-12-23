using TodoManager.Models;

namespace TodoManager.Helper.Interfaces {
    public interface ISessao {
        Usuario BuscarSessaoUsuario();

        public void CriarSessaoDoUsuario(Usuario usuario);

        public void RemoverSessaoDoUsuario();
    }
}
