using Microsoft.AspNetCore.Mvc;
using TodoManager.Repositories.Interfaces;
using TodoManager.Models;
using TodoManager.Strategy;
using TodoManager.Helper.Interfaces;

namespace TodoManager.Controllers {
    public class AdministradorController : Controller {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepostory;
        private readonly ISessao _sessao;

        public AdministradorController(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository, ISessao sessao) {
            _tarefaRepository = tarefaRepository;
            _usuarioRepostory = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Tarefas() {
            if(_sessao.BuscarSessaoUsuario() != null){
                IEnumerable<Tarefa> tarefas = _tarefaRepository.SelecionarTarefasNaoConcluidas().ToList();
                foreach(Tarefa tarefa in tarefas) {
                    if (VerficarDataConclusaoPassou.Verificar(tarefa.TRF_DataConclusao)) {
                        _tarefaRepository.AtualizarParaNaoConcluida(tarefa);
                    }
                }
                return View(tarefas);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult TodasTarefas() {
            if (_sessao.BuscarSessaoUsuario() != null) {
                IEnumerable<Tarefa> tarefas = _tarefaRepository.SelecionarTarefas().ToList();
                foreach (Tarefa tarefa in tarefas) {
                    if (VerficarDataConclusaoPassou.Verificar(tarefa.TRF_DataConclusao)) {
                        _tarefaRepository.AtualizarParaNaoConcluida(tarefa);
                    }
                }
                return View(tarefas);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Usuarios() {
            if (_sessao.BuscarSessaoUsuario() != null) {
                var usuarios = _usuarioRepostory.SelecionarUsuarios();
                return View(usuarios);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult DeleteTarefa(int id) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                _tarefaRepository.ApagarTarefa(id);
                TempData["SucessoApagarTarefa"] = "Tarefa apagada com sucesso";
                return RedirectToAction("Tarefas", "Administrador");
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult DeleteUsuario(int id) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                _usuarioRepostory.ApagarUsuario(id);
                TempData["SucessoApagarUsuario"] = "Usuario apagado com sucesso";
                return RedirectToAction("Usuarios", "Administrador");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                return View(_usuarioRepostory.SelecionarUsuarioPorId(id));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult EditarUsuarioPost([FromForm]Usuario usuario) {
            _usuarioRepostory.AlterarUsuario(usuario);
            TempData["SucessoAlterarUsuario"] = "Usuario alterado com sucesso";
            return RedirectToAction("Usuarios", "Administrador");
        }
    }
}
