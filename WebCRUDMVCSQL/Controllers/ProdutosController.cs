#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCRUDMVCSQL.Models;

namespace WebCRUDMVCSQL.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto _context;

        public ProdutosController(Contexto context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produto.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Peso,Preco")] Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
                ModelState.AddModelError("Nome", "Informe o nome do produto");

            if (produto.Peso <= 0)
                ModelState.AddModelError("Peso", "O peso deve ser maior que zero");

            if (produto.Preco <= 0)
                ModelState.AddModelError("Preco", "O preço deve ser maior que zero");

            if (!ModelState.IsValid)
                return View(produto);

            _context.Add(produto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Peso,Preco")] Produto produto)
        {
            if (id != produto.Id)
                return NotFound();

            if (string.IsNullOrWhiteSpace(produto.Nome))
                ModelState.AddModelError("Nome", "Informe o nome do produto");

            if (produto.Nome.Length < 3)
                ModelState.AddModelError("Nome", "O nome deve ter no mínimo 3 caracteres");

            if (produto.Peso <= 0)
                ModelState.AddModelError("Peso", "O peso deve ser maior que zero");

            if (produto.Preco <= 0)
                ModelState.AddModelError("Preco", "O preço deve ser maior que zero");

            if (!ModelState.IsValid)
                return View(produto);

            try
            {
               
                
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.Id))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: Produtos/Delete/5
        public async Task<IActionResult> delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
