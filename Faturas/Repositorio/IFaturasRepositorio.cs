﻿using Faturas.Entidades;
using Faturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Repositorio
{
    public interface IFaturasRepositorio
    {
        IEnumerable<Cliente> ListarClientes();        
        Cliente ObterCliente(Guid id);
        void AddCliente(Cliente cliente);

        IEnumerable<Produto> ListarProdutos();
        Produto ObterProduto(Guid id);
        void AddProduto(Produto produto);

        IEnumerable<Fatura> ListarFaturas();
        Fatura ObterFatura(Guid id);
        void AddFatura(Fatura fatura);

        IEnumerable<Linha> ListasLinhasFatura(Guid id);

        IEnumerable<Transacao> ListarTransacoes();
        IEnumerable<Transacao> ListarTransacaoCliente(Guid id);

        IEnumerable<Pagamento> ListarPagamentos();
        Pagamento ObterPagamento(Guid id);
        void AddPagamento(Pagamento pagamento);
    }
}
