using Microsoft.AspNetCore.Mvc;
using TodoManager.Helper;
using TodoManager.Helper.Interfaces;
using TodoManager.Models;
using TodoManager.Repositories;
using TodoManager.Repositories.Interfaces;
using TodoManager.Strategy;

namespace TodoManager.Controllers {
    public class UsuarioController : Controller {
        private readonly ISessao _sessao;
        private readonly ITarefaRepository _tarefaRepository;

        public UsuarioController(ISessao sessao, ITarefaRepository tarefaRepository) {
            _sessao = sessao;
            _tarefaRepository = tarefaRepository;
        }
        public IActionResult Tarefas() {
            if (_sessao.BuscarSessaoUsuario() != null) {
                Usuario usuario = _sessao.BuscarSessaoUsuario();

                IEnumerable<Tarefa> tarefas = _tarefaRepository.SelecionarTarefasNaoConcluidasDoUsuario(usuario.USU_Id).ToList();

                foreach (Tarefa tarefa in tarefas) {
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
                Usuario usuario = _sessao.BuscarSessaoUsuario();

                IEnumerable<Tarefa> tarefas = _tarefaRepository.SelecionarTarefasDoUsuario(usuario.USU_Id).ToList();

                foreach (Tarefa tarefa in tarefas) {
                    if (VerficarDataConclusaoPassou.Verificar(tarefa.TRF_DataConclusao)) {
                        _tarefaRepository.AtualizarParaNaoConcluida(tarefa);
                    }
                }

                return View(tarefas);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult MeuPerfil() {
            if (_sessao.BuscarSessaoUsuario() != null) {
                Usuario usuario = _sessao.BuscarSessaoUsuario();
                return View(usuario);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AlterarSenha() {
            if (_sessao.BuscarSessaoUsuario() != null) {
                Usuario usuario = _sessao.BuscarSessaoUsuario();
                return View(usuario);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
