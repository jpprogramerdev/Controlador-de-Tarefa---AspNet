using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TodoManager.Models;

namespace TodoManager.ViewComponents {
    public class Menu : ViewComponent{
        public async Task<IViewComponentResult> InvokeAsync() {
            string sessaoLogado = HttpContext.Session.GetString("SessaoUsuarioLogado");

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoLogado);

            return View(usuario);
        }
    }
}
