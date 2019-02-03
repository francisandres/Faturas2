using Faturas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Data
{
    public class FaturasContext : DbContext{

        public FaturasContext(DbContextOptions<FaturasContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Linha> Linhas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

  


    }
}
