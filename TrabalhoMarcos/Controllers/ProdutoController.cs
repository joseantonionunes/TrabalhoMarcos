using TrabalhoMarcos.Data;
using TrabalhoMarcos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrabalhoMarcos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AulaContext _context;

        //public ProdutoController(AulaContext context)
        //{
        //    _context = context;
        //}

        public async Task<IActionResult> BuscarProdutos()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        public IActionResult CadastroProduto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroProduto([Bind("Id,Nome,Fabricante,Codigo,Quantidade,ValordeCompra,ValordeVenda,Descricao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("BuscarProdutos");
            }

            return View(produto);
        }
    }
}
