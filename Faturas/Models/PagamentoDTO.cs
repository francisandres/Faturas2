using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
    public class PagamentoDTO
    {
        public Guid PagamentoId { get; set; }
        public string TipoPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public Guid bancoId { get; set; }

        public Guid FaturaId { get; set; }

        public Guid ClienteId { get; set; }
        public Guid TransacaoId { get; set; }
    }
}
