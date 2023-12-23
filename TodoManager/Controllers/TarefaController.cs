using Microsoft.AspNetCore.Mvc;
using TodoManager.Repositories.Interfaces;
using TodoManager.Models;
using TodoManager.ViewModel;
using TodoManager.Helper.Interfaces;
using TodoManager.Strategy;

namespace TodoManager.Controllers {
    public class TarefaController : Controller {
        private readonly IStatusTarefaRepository _statusTarefaRepository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPrioridadeRepository _prioridadeRepository;

        public TarefaController(ITarefaRepository tarefaRepository, IStatusTarefaRepository statusTarefaRepository, ISessao sessao, IUsuarioRepository usuarioRepository, IPrioridadeRepository prioridadeRepository) {
            _tarefaRepository = tarefaRepository;
            _statusTarefaRepository = statusTarefaRepository;
            _sessao = sessao;
            _usuarioRepository = usuarioRepository;
            _prioridadeRepository = prioridadeRepository;
        }
    public IActionResult Index(int id) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                return View(construirUsuarioTarefa(id));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Editar(int id) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                UsuarioTarefa usuarioTarefa = construirUsuarioTarefa(id);
                usuarioTarefa.Usuarios = _usuarioRepository.SelecionarUsuarios();
                usuarioTarefa.Prioridades = _prioridadeRepository.SelecionarPrioridades();
                return View(usuarioTarefa);
            }
            return RedirectToAction("Index", "Login");
        }
    

        [HttpPost]
        public IActionResult EditarPost([FromForm]UsuarioTarefa viewModelAtualizada) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                if (ModelState.IsValid) { 
                    if (!VerificarData.verificar(viewModelAtualizada.Tarefa.TRF_DataConclusao)) {
                        TempData["ErrorDate"] = "A data de conclusão deve ser maior que a data atual";
                        UsuarioTarefa usuarioTarefa = construirUsuarioTarefa(viewModelAtualizada.Tarefa.TRF_Id);
                        usuarioTarefa.Usuarios = _usuarioRepository.SelecionarUsuarios();
                        usuarioTarefa.Prioridades = _prioridadeRepository.SelecionarPrioridades();
                        return View("Editar", usuarioTarefa);
                    }
                    _tarefaRepository.AtualizarTarefa(viewModelAtualizada.Tarefa);
                    TempData["SucessoAtualizadaTarefa"] = "Tarefa atualizada com sucesso";
                }
                return View("Index", construirUsuarioTarefa(viewModelAtualizada.Tarefa.TRF_Id));
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult UpdateStatusTarefa(int id) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                int idStatus = VerificarStatus(_tarefaRepository.SelecionarTarefaPorId(id));
                _tarefaRepository.AtualizarStatusTarefa(idStatus, _statusTarefaRepository.SelecionarStatusPorId(idStatus), _tarefaRepository.SelecionarTarefaPorId(id));

                return View("Index", construirUsuarioTarefa(id));
            }
            return RedirectToAction("Index", "Login");
        }

        private int VerificarStatus(Tarefa tarefa) {
            if (tarefa.TRF_STS_Id == 1) {
                return 2;
            } else if (tarefa.TRF_STS_Id == 2) {
                return 3;
            }
            return 1;
        }

        private UsuarioTarefa construirUsuarioTarefa(int id) {
            UsuarioTarefa usuarioTarefa = new();
            if (_sessao.BuscarSessaoUsuario() != null) {
                usuarioTarefa.Usuario = _sessao.BuscarSessaoUsuario();
            }
            usuarioTarefa.Tarefa = _tarefaRepository.SelecionarTarefaPorId(id);

            return usuarioTarefa;
        }

    }
}