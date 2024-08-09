using TrabalhoMarcos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace TrabalhoMarcos.Data
{
    public class AulaContext : DbContext
    {
        public AulaContext(DbContextOptions<AulaContext> options) : base(options)
        {
        }

        public DbSet<TrabalhoMarcos.Models.Cliente> Clientes { get; set; } = default!;

        public DbSet<TrabalhoMarcos.Models.Produto> Produtos { get; set; } = default!;
    }
}
