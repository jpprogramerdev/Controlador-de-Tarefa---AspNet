using Microsoft.AspNetCore.Mvc;
using TodoManager.Helper.Interfaces;
using TodoManager.Models;
using TodoManager.Repositories.Interfaces;

namespace TodoManager.Controllers {
    public class LoginController : Controller {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao) {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index() {
            //Se usuario estiver logado, mandar para index de tarefas
            if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("EncaminharUsuario", "Login", _sessao.BuscarSessaoUsuario);

            return View();
        }

        public IActionResult Logout() {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel login) {
            try {
                if (ModelState.IsValid) {
                    Usuario usuario = _usuarioRepository.LoginUsuario(login);
                    if(usuario != null) {
                        _sessao.CriarSessaoDoUsuario(usuario);
                        if (usuario.USU_TPU_Id == 1) {
                            return RedirectToAction("Tarefas", "Administrador", usuario);
                        }else if (usuario.USU_TPU_Id == 2) {
                            return RedirectToAction("Tarefas", "Usuario", usuario);
                        }
                    }
                    TempData["MessageLogin"] = "Email e/ou senha invalido";
                    return View("Index");
                }
                TempData["MessageLogin"] = "Email e/ou senha invalido";
                return View("Index");
            } catch(Exception ex) {
                TempData["MessageLogin"] = "Não foi possível fazer seu login, tente novamente\n\nErro: " + ex.Message;
                return View("Index");
            }
        }

        public IActionResult EncaminharUsuario(Usuario usuario) {
            if(usuario.USU_TPU_Id == 1) {
                return RedirectToAction("Tarefas", "Administrador", usuario);
            }
            return RedirectToAction("Index", "Usuario", usuario);
        }
    }
}
