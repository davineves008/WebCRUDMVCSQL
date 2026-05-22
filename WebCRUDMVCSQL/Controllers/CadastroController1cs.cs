using Microsoft.AspNetCore.Mvc;
using WebCRUDMVCSQL.Models;

using WebCRUDMVCSQL.Repositorios;

namespace WebCRUDMVCSQL.Controllers
{
    public class CadastroController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Index(Usuarios usuario)
        {
            if (usuario == null)
            {
                ViewBag.Erro = "Dados inválidos";

                return View();
            }

            UsuarioRepositorio repo =
                new UsuarioRepositorio();

            if (repo.CamposVazios(usuario))
            {
                ViewBag.Erro =
                    "Preencha todos os campos";

                return View();
            }

            repo.Cadastrar(usuario);

            return RedirectToAction("Index", "Login");
        }
    }
}