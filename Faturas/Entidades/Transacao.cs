using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class Transacao
    {
        public Guid TransacaoId { get; set; }

        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Cliente")]
        public Guid ClienteId { get; set; }


        public virtual Fatura Fatura { get; set; }

        [ForeignKey("Fatura")]
        public Guid? FaturaId { get; set; }

        public virtual Pagamento Pagamento { get; set; }
        [ForeignKey("Pagamento")]
        public Guid PagamentoId { get; set; }


        public string Tipo_transacao { get; set; }

        public decimal Valor_transacao { get; set; }


    }
}
