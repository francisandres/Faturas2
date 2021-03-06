﻿using Faturas.Entidades;
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
        public DbSet<MovimentoBancario> MovimentosBancarios {get; set;}
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<ReceitaOrcamento> ReceitaOrcamentos { get; set; }
        public DbSet<CustoOrcamento> CustoOrcamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Vencimento> Vencimentos { get; set; }




    }
}
