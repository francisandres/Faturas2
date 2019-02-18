using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class CustoOrcamento
    {
        public Guid custoOrcamentoId { get; set; }
        public string nomeDoCusto { get; set; }
        public decimal valorDoCusto { get; set; }
        public DateTime data { get; set; }
    }
}
