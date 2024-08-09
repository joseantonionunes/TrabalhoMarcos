using TrabalhoMarcos.Data;
using TrabalhoMarcos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Aula2407.Controllers
{
    public class ClienteController : Controller
    {

        private readonly AulaContext _context;

        public ClienteController(AulaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> BuscarClientes()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        public async Task<IActionResult> DetalhesClientes(int id)
        {
            return View(await _context.Clientes.FindAsync(id));
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public async Task<IActionResult> AlterarCliente(int id)
        {
            return View(await _context.Clientes.FindAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroCliente([Bind("Id,Nome,RG,CPF,Usuario,Senha,CEP,UF,Cidade,Bairro,Rua,Numero,Completo")]  Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("BuscarClientes");
            }
            
            return View(cliente);
        }

        
    }
}
