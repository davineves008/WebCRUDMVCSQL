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

        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            // CAMPOS VAZIOS
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Erro = "Email e senha são obrigatórios";
                return View();
            }

            email = email.Trim();

            // TAMANHO DO EMAIL
            if (email.Length > 100)
            {
                ViewBag.Erro = "Email muito grande";
                return View();
            }

            // FORMATO DO EMAIL
            if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute()
                .IsValid(email))
            {
                ViewBag.Erro = "Digite um email válido";
                return View();
            }

            // TAMANHO DA SENHA
            if (senha.Length < 6)
            {
                ViewBag.Erro = "A senha deve ter no mínimo 6 caracteres";
                return View();
            }

            UsuarioRepositorio repo = new UsuarioRepositorio();

            Usuarios usuario = repo.FazerLogin(email, senha);

            if (usuario == null)
            {
                ViewBag.Erro = "Email ou senha inválidos";
                return View();
            }

            // Salva dados do usuário na sessão
            HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

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