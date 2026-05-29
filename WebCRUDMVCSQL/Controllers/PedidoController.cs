using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCRUDMVCSQL.Models;

namespace WebCRUDMVCSQL.Controllers
{
    public class PedidosController : Controller
    {
        private readonly Contexto _context;

        public PedidosController(Contexto context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            var pedidos = _context.pedido
                .Include(p => p.Cliente)
                .Include(p => p.Usuario)
                .Include(p => p.Produto);

            return View(await pedidos.ToListAsync());
        }

        // DETALHES
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.pedido
                .Include(p => p.Cliente)
                .Include(p => p.Usuario)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // ABRIR CREATE
        public IActionResult Create()
        {
            CarregarListas();

            return View();
        }
        // SALVAR CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            // DEFINE DATA E HORA AUTOMÁTICA
            pedido.DataPedido = DateTime.Now;

            // VALIDAÇÕES
            if (pedido.ClienteId <= 0)
            {
                ViewBag.Erro = "Selecione um cliente";
            }
            else if (pedido.UsuarioId <= 0)
            {
                ViewBag.Erro = "Selecione um usuário";
            }
            else if (pedido.ProdutoId <= 0)
            {
                ViewBag.Erro = "Selecione um produto";
            }
            else if (pedido.Quantidade <= 0)
            {
                ViewBag.Erro = "Quantidade inválida";
            }
            else if (pedido.ValorTotal <= 0)
            {
                ViewBag.Erro = "Valor total inválido";
            }

            if (ViewBag.Erro != null)
            {
                CarregarListas();

                return View(pedido);
            }

            _context.Add(pedido);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // ABRIR EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            CarregarListas();

            return View(pedido);
        }

        // SALVAR EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            // VALIDAÇÕES
            if (pedido.ClienteId <= 0)
            {
                ViewBag.Erro = "Selecione um cliente";
            }
            else if (pedido.UsuarioId <= 0)
            {
                ViewBag.Erro = "Selecione um usuário";
            }
            else if (pedido.ProdutoId <= 0)
            {
                ViewBag.Erro = "Selecione um produto";
            }
            else if (pedido.Quantidade <= 0)
            {
                ViewBag.Erro = "Quantidade inválida";
            }
            else if (pedido.ValorTotal <= 0)
            {
                ViewBag.Erro = "Valor total inválido";
            }
            else if (pedido.DataPedido.Date > DateTime.Now.Date)
            {
                ViewBag.Erro = "Data inválida";
            }

            if (ViewBag.Erro != null)
            {
                CarregarListas();

                return View(pedido);
            }

            try
            {
                _context.Update(pedido);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(pedido.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // ABRIR DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.pedido
                .Include(p => p.Cliente)
                .Include(p => p.Usuario)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // CONFIRMAR DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.pedido.FindAsync(id);

            if (pedido != null)
            {
                _context.pedido.Remove(pedido);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // CARREGAR LISTAS
        private void CarregarListas()
        {
            ViewBag.Clientes = new SelectList(
                _context.Clientes.ToList(),
                "Id",
                "Nome"
            );

            ViewBag.Usuarios = new SelectList(
                _context.Usuarios.ToList(),
                "Id",
                "Nome"
            );

            ViewBag.Produtos = new SelectList(
                _context.Produto.ToList(),
                "Id",
                "Nome"
            );
        }

        // VERIFICAR EXISTENCIA
        private bool PedidoExists(int id)
        {
            return _context.pedido.Any(e => e.Id == id);
        }
    }
}