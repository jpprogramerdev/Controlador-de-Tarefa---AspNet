using TodoManager.Context;
using TodoManager.Models;
using TodoManager.Repositories.Interfaces;
using System.Linq;
using TodoManager.Strategy;
using Microsoft.EntityFrameworkCore;

namespace TodoManager.Repositories {
    public class UsuarioRepository : IUsuarioRepository {
        public readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) { 
            _context = context;
        }

        public Usuario LoginUsuario(LoginModel login) => 
            _context
            .Usuarios
            .Where(
                u => u.USU_Email.ToUpper().Trim() == login.LoginEmail.ToUpper().Trim()  
                &&  u.USU_Senha == login.LoginSenha.GerarHash()
                )
            .FirstOrDefault();

        public IEnumerable<Usuario> SelecionarUsuarios() =>
            _context.Usuarios;

        public void RegistrarUsuario(Usuario usuario) {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario SelecionarUsuarioPorId(int id) => _context.Usuarios.Where(u => u.USU_Id == id).FirstOrDefault();

        public void AlterarUsuario(Usuario usuario) {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void ApagarUsuario(int id) {
            IEnumerable<Tarefa> TarefasParaDeletar = _context.Tarefas.Where(t => t.TRF_USU_Id == id);

            foreach(Tarefa tarefa in TarefasParaDeletar) {
                _context.Tarefas.Remove(tarefa);
            }
            _context.Usuarios.Remove(SelecionarUsuarioPorId(id));

            _context.SaveChanges();
        }


    }
}
