using Newtonsoft.Json;
using TodoManager.Helper.Interfaces;
using TodoManager.Models;

namespace TodoManager.Helper {
    public class Sessao : ISessao {
        private readonly IHttpContextAccessor _HttpContext;

        public Sessao(IHttpContextAccessor httpContext){
            _HttpContext = httpContext;
        }

        public Usuario BuscarSessaoUsuario() {
            string sessaoUsuario = _HttpContext.HttpContext.Session.GetString("SessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(Usuario usuario) {
            string usuarioString = JsonConvert.SerializeObject(usuario);
            _HttpContext.HttpContext.Session.SetString("SessaoUsuarioLogado", usuarioString);
        }

        public void RemoverSessaoDoUsuario() {
            _HttpContext.HttpContext.Session.Remove("SessaoUsuarioLogado");
        }
    }
}
