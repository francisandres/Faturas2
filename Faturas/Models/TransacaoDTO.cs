using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
    public class TransacaoDTO
    {
        public Guid TransacaoId { get; set; }
                
        public Guid ClienteId { get; set; }

        public Guid FaturaId { get; set; }
        
        public string Tipo_transacao { get; set; }

        public decimal Valor_transacao { get; set; }
    }
}
