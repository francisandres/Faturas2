using Faturas.Data;
using Faturas.Entidades;
using Faturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Repositorio
{
    public class FaturasRepositorio : IFaturasRepositorio
    {
        private readonly FaturasContext _ctx;

        public FaturasRepositorio(FaturasContext ctx)
        {
       

            _ctx = ctx;

            
        }

     

        public IEnumerable<Cliente> ListarClientes()
        {
            if (_ctx.Clientes.Count() == 0)
            {
                _ctx.Clientes.Add(new Cliente { Primeiro_nome = "Cliente",
                                                Ultimo_nome = "Indiferenciado",
                                                Email="no-email@noemail.com"});
                _ctx.SaveChanges();
            }
            return _ctx.Clientes.ToList();
         
        }

    

        public Cliente ObterCliente(Guid id)
        {
            var cliente = _ctx.Clientes.Find(id);
            return cliente;
        }

        public void AddCliente(Cliente cliente)
        {
            cliente.Saldo = 0;
            _ctx.Clientes.Add(cliente);
            _ctx.SaveChanges();
        }

        public IEnumerable<Produto> ListarProdutos()
        {
            if(_ctx.Produtos.Count()== 0)
            {
                _ctx.Produtos.Add(new Produto {
                       Nome = "IPhoneX",
                       Descricao = "Um dos melhores telefones de todos os tempos",
                       Preco=450000
                });
                _ctx.SaveChanges();
            }

            return _ctx.Produtos.ToList();
        }

        public Produto ObterProduto(Guid id)
        {
            var produto = _ctx.Produtos.Find(id);
            return produto;
        }


        public void AddProduto(Produto produto)
        {
            _ctx.Produtos.Add(produto);
            _ctx.SaveChanges();
        }

        public IEnumerable<Fatura> ListarFaturas()
        {
            if(_ctx.Faturas.Count()==0)
            {
                _ctx.Faturas.Add(
                        new Fatura
                        {
                            totalFatura = 25000,
                            valorPago = 15000,
                            nome = "Cliente Indiferenciado",
                            Linha = new Linha[]{new Linha
                            {
                                precoVenda = 25000,
                                quantidade = 7
                            },
                            new Linha
                            {
                                precoVenda=35000,
                                quantidade=5
                            }
                                               }
                        }
                    );
                _ctx.SaveChanges();
            }
            
            return _ctx.Faturas.ToList();
        }

        public Fatura ObterFatura(Guid id)
        {
            var fatura = _ctx.Faturas.Find(id);
            return fatura; 
        }

        public void AddFatura(Fatura fatura)
        {

            Transacao trans = new Transacao();
            trans.Cliente = _ctx.Clientes.Find(fatura.clienteId);
            trans.ClienteId = fatura.clienteId;
            trans.Fatura = fatura;
            trans.FaturaId = fatura.faturaId;
            trans.Tipo_transacao = "débito";
            trans.Valor_transacao = fatura.totalFatura;
            _ctx.Transacoes.Add(trans);

            Cliente cli;
            cli = _ctx.Clientes.Find(fatura.clienteId);
            cli.Saldo = cli.Saldo - fatura.totalFatura;
            fatura.cliente = cli;
            fatura.estadoDaFatura = "Por Pagar!";
            _ctx.Faturas.Add(fatura);
            if(fatura.Linha.Any())
            {
                foreach(var linha in fatura.Linha)
                {
                    _ctx.Produtos.Find(linha.produtoId).Stock = _ctx.Produtos.Find(linha.produtoId).Stock - linha.quantidade;
                }
            }
            _ctx.SaveChanges();
        }


        public IEnumerable<Linha> ListasLinhasFatura(Guid id)
        {
            return _ctx.Linhas.Where(i => i.faturaId == id).ToList();
        }

        public IEnumerable<Transacao> ListarTransacoes()
        {
            return _ctx.Transacoes.ToList();
        }

        public IEnumerable<Transacao> ListarTransacaoCliente(Guid id)
        {
            return _ctx.Transacoes.Where(c => c.ClienteId.Equals(id)).ToList();
        }

        public IEnumerable<Pagamento> ListarPagamentos()
        {
            return _ctx.Pagamentos.ToList();
        }

        public Pagamento ObterPagamento(Guid id)
        {
            return _ctx.Pagamentos.Find(id);
        }

        public void AddPagamento(Pagamento pagamento)
        {
            Transacao trans = new Transacao();
            trans.Cliente = _ctx.Clientes.Find(pagamento.ClienteId);
            trans.ClienteId = pagamento.ClienteId;
            trans.Fatura = _ctx.Faturas.Find(pagamento.FaturaId);
            trans.FaturaId = pagamento.FaturaId;
            trans.Tipo_transacao = "crédito";
            trans.Valor_transacao = pagamento.ValorPago;

            _ctx.Transacoes.Add(trans);

            Cliente cli;
            cli = _ctx.Clientes.Find(pagamento.ClienteId);
            cli.Saldo = cli.Saldo + pagamento.ValorPago;
            Banco bank = _ctx.Bancos.Find(pagamento.bancoId);
            bank.saldo = bank.saldo + pagamento.ValorPago;
            if(pagamento.FaturaId != null){
               Fatura fat =  _ctx.Faturas.Find(pagamento.FaturaId);
               fat.valorPago = fat.valorPago + pagamento.ValorPago;
            }

            _ctx.Pagamentos.Add(pagamento);
            _ctx.SaveChanges();
        }

        public IEnumerable<Banco> ListarBancos()
        {
            return _ctx.Bancos.ToList();
        }

        public Banco ObterBancoPorId(Guid id)
        {
            return _ctx.Bancos.Find(id);
        }

        public void AddBanco(Banco banco)
        {
            _ctx.Bancos.Add(banco);
            _ctx.SaveChanges();
        }

        public IEnumerable<ContaBancaria> ListarContasBancarias(){
            return _ctx.ContasBancarias.ToList();
        }

        public ContaBancaria ObterContaBancariaPorId(Guid id){
            return _ctx.ContasBancarias.Find(id);
        }

        public void AddConta(ContaBancaria contabank)
        {
            _ctx.ContasBancarias.Add(contabank);
            _ctx.SaveChanges();
        }

        public IEnumerable<ContaBancaria> ListarContasNoBanco(Guid id)
        {
            return _ctx.ContasBancarias.Where(i => i.bancoId ==id).ToList();
        }

        public IEnumerable<MovimentoBancario> ListarMovimentosBancarios(){
            return _ctx.MovimentosBancarios.ToList();
        }

        public MovimentoBancario ObterMovimentoBancarioPorId(Guid id){
            return _ctx.MovimentosBancarios.Find(id);
        }
        public void AddMovimentoBancario(MovimentoBancario movbank){
            _ctx.MovimentosBancarios.Add(movbank);
        }

        public IEnumerable<Funcionario> ListarFuncionarios()
        {
            return _ctx.Funcionarios.ToList();
        }

        public Funcionario ObterFuncionario(Guid id)
        {
            return _ctx.Funcionarios.Find(id);
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            _ctx.Funcionarios.Add(funcionario);
            _ctx.SaveChanges();
        }
    }
}
