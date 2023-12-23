using Microsoft.AspNetCore.Mvc;
using TodoManager.Models;
using TodoManager.Repositories.Interfaces;
using TodoManager.Helper.Interfaces;
using TodoManager.Strategy;

namespace TodoManager.Controllers {
    public class RegistroUsuarioController : Controller {
        private readonly IUsuarioRepository _usuarioRepostory;
        private readonly ISessao _sessao;

        public RegistroUsuarioController(IUsuarioRepository usuarioRepository, ISessao sessao) {
            _usuarioRepostory = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index() {
            if (_sessao.BuscarSessaoUsuario() != null) {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Usuario usuarioRegistrado) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                usuarioRegistrado.USU_TPU_Id = 2;
                usuarioRegistrado.USU_Senha = usuarioRegistrado.USU_Senha.GerarHash();
                _usuarioRepostory.RegistrarUsuario(usuarioRegistrado);
                TempData["SucessoAddUsuario"] = "Usuario adicionado com sucesso";
                return View("Index");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult RegistrarUsuarioComNovaSenha(Usuario usuario) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                usuario.USU_Senha = usuario.USU_Senha.GerarHash();
                _usuarioRepostory.AlterarUsuario(usuario);
                TempData["SucessoAlterarSenha"] = "Senha alterada com sucesso";
                return RedirectToAction("AlterarSenha", "Usuario");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
