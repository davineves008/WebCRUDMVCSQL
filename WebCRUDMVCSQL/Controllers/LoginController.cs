using Microsoft.AspNetCore.Mvc;
using WebCRUDMVCSQL.Models;
using WebCRUDMVCSQL.Repositorios;

namespace WebCRUDMVCSQL.Controllers
{
    public class LoginController : Controller
    {
        // ABRIR TELA
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // FAZER LOGIN
        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            // CAMPOS VAZIOS
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Erro =
                    "Email e senha são obrigatórios";

                return View();
            }

            // VALIDAR EMAIL
            if (!email.Contains("@") ||
                !email.Contains("."))
            {
                ViewBag.Erro =
                    "Digite um email válido";

                return View();
            }

            // VALIDAR SENHA
            if (senha.Length < 6)
            {
                ViewBag.Erro =
                    "A senha deve ter no mínimo 6 caracteres";

                return View();
            }

            UsuarioRepositorio repo =
                new UsuarioRepositorio();

            Usuarios usuario =
                repo.FazerLogin(email, senha);

            // LOGIN INVÁLIDO
            if (usuario == null)
            {
                ViewBag.Erro =
                    "Email ou senha inválidos";

                return View();
            }

            // LOGIN OK
            return RedirectToAction("Index", "Home");
        }


        // ABRIR TELA CADASTRO
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}