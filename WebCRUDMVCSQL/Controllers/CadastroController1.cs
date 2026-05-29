using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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
        public IActionResult Index(Usuarios usuario)
        {
            if (usuario == null)
            {
                ViewBag.Erro = "Dados inválidos";
                return View(usuario);
            }

            UsuarioRepositorio repo =
                new UsuarioRepositorio();

            // CAMPOS VAZIOS
            if (repo.CamposVazios(usuario))
            {
                ViewBag.Erro =
                    "Preencha todos os campos";

                return View(usuario);
            }

            // NOME
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                ViewBag.Erro =
                    "O nome é obrigatório";

                return View(usuario);
            }

            // IDADE
            if (usuario.Idade < 1 || usuario.Idade > 120)
            {
                ViewBag.Erro =
                    "Informe uma idade válida";

                return View(usuario);
            }

            // EMAIL
            if (string.IsNullOrWhiteSpace(usuario.Email)
                || !usuario.Email.Contains("@"))
            {
                ViewBag.Erro =
                    "Email inválido";

                return View(usuario);
            }

            // SENHA
            if (string.IsNullOrWhiteSpace(usuario.Senha)
                || usuario.Senha.Length < 6)
            {
                ViewBag.Erro =
                    "A senha deve ter no mínimo 6 caracteres";

                return View(usuario);
            }

            // CPF
            string cpf =
                usuario.CPF.Replace(".", "")
                           .Replace("-", "")
                           .Trim();

            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                ViewBag.Erro =
                    "CPF deve conter 11 números";

                return View(usuario);
            }

            // WHATSAPP
            string whatsapp =
                usuario.Whatsapp.Replace("(", "")
                                 .Replace(")", "")
                                 .Replace("-", "")
                                 .Replace(" ", "")
                                 .Trim();

            if (!Regex.IsMatch(whatsapp, @"^\d{10,11}$"))
            {
                ViewBag.Erro =
                    "Whatsapp inválido. Digite apenas números";

                return View(usuario);
            }

            // IMPEDIR LETRAS NO TELEFONE
            if (Regex.IsMatch(usuario.Whatsapp, @"[a-zA-Z]"))
            {
                ViewBag.Erro =
                    "O Whatsapp não pode conter letras";

                return View(usuario);
            }

            // ESTADO CIVIL
            if (string.IsNullOrWhiteSpace(usuario.Estado_Civil))
            {
                ViewBag.Erro =
                    "Informe o estado civil";

                return View(usuario);
            }

            // CIDADE
            if (string.IsNullOrWhiteSpace(usuario.Cidade))
            {
                ViewBag.Erro =
                    "Informe a cidade";

                return View(usuario);
            }

            // ESTADO
            if (string.IsNullOrWhiteSpace(usuario.Estado))
            {
                ViewBag.Erro =
                    "Informe o estado";

                return View(usuario);
            }

            // EMAIL JÁ EXISTE
            if (repo.EmailExiste(usuario.Email))
            {
                ViewBag.Erro =
                    "Este email já está cadastrado";

                return View(usuario);
            }

            // CADASTRAR
            repo.Cadastrar(usuario);

            ViewBag.Sucesso =
                "Cadastro realizado com sucesso";

            return RedirectToAction("Index", "Login");
        }
    }
}