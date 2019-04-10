using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class Vencimento
    {
        [Key]
        public Guid vencimentoId { get; set; }
    }
}
