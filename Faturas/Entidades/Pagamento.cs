using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class Pagamento
    {
        [Key]
        public Guid PagamentoId { get; set; }
        public string TipoPagamento { get; set; }
        public decimal ValorPago { get; set; }

        public virtual Fatura Fatura { get; set; }
        public Guid FaturaId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public Guid bancoId { get; set; }

        public virtual Transacao Transacao { get; set; }
        [ForeignKey("Transacao")]
        public Guid TransacaoId { get; set; }

    }
}
