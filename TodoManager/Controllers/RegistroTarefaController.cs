using Microsoft.AspNetCore.Mvc;
using TodoManager.Helper.Interfaces;
using TodoManager.Models;
using TodoManager.Repositories.Interfaces;
using TodoManager.Strategy;
using TodoManager.ViewModel;

namespace TodoManager.Controllers {
    public class RegistroTarefaController : Controller {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IPrioridadeRepository _prioridadeTarefa;
        private readonly IStatusTarefaRepository _statusTarefaRepository;
        private readonly ISessao _sessao;

        public RegistroTarefaController(IUsuarioRepository usuarioRepository, ITarefaRepository tarefaRepository, IPrioridadeRepository prioridadeTarefa, IStatusTarefaRepository statusTarefaRepository, ISessao sessao) {
            _usuarioRepository = usuarioRepository;
            _tarefaRepository = tarefaRepository;
            _prioridadeTarefa = prioridadeTarefa;
            _statusTarefaRepository = statusTarefaRepository;
            _sessao = sessao;
        }

        public IActionResult Index() {
            if (_sessao.BuscarSessaoUsuario() != null) {
                UsuarioTarefa viewModel = new();
                viewModel.Prioridades = _prioridadeTarefa.SelecionarPrioridades();
                viewModel.Usuarios = _usuarioRepository.SelecionarUsuarios();
                return View(viewModel);
            }
            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public IActionResult RegistrarTarefa(Tarefa tarefa) {
            if (_sessao.BuscarSessaoUsuario() != null) {
                UsuarioTarefa viewModel = new();
                viewModel.Prioridades = _prioridadeTarefa.SelecionarPrioridades();
                viewModel.Usuarios = _usuarioRepository.SelecionarUsuarios();

                if (ModelState.IsValid) {
                    if (!VerificarData.verificar(tarefa.TRF_DataConclusao)) {
                        TempData["ErrorDate"] = "A data de conclusão deve ser maior que a data atual";
                        return View("Index", viewModel);
                    }
                    tarefa.TRF_DataCriada = DateTime.Now;
                    tarefa.TRF_STS_Id = 1;

                    tarefa.Usuario = _usuarioRepository.SelecionarUsuarioPorId(tarefa.TRF_USU_Id);
                    tarefa.PrioridadeTarefa = _prioridadeTarefa.SelecionarPrioridaePorId(tarefa.TRF_PRD_Id);
                    tarefa.StatusTarefa = _statusTarefaRepository.SelecionarStatusPorId(tarefa.TRF_STS_Id);
                    _tarefaRepository.SalvarTarefa(tarefa);

                    TempData["SucessoAddTarefa"] = "Tarefa adicionada com sucesso";
                }
                return View("Index", viewModel);
            }
            return RedirectToAction("Index", "Login");
        }


    }
}
