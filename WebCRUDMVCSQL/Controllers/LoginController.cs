using Microsoft.AspNetCore.Mvc;
using WebCRUDMVCSQL.Repositorios;

namespace Projeto.Controllers
{
    public class LoginController : Controller
    {
        // ABRIR A TELA
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // FAZER LOGIN
        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            UsuarioRepositorio repo = new UsuarioRepositorio();

            var usuario = repo.FazerLogin(email, senha);

            if (usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Email ou senha inválidos";

            return View();
        }
        //Abrir tela de cadastro;
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}