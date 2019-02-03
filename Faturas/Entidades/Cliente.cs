using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
   
        public class Cliente
        {
            
       
            [Key]
            public Guid? ClienteId { get; set; }
            public string Primeiro_nome { get; set; }
            public string Ultimo_nome { get; set; }
            public string Email { get; set; }
            public decimal Saldo { get; set; }
            public virtual ICollection<Fatura> Faturas { get; set; } =    new List<Fatura>();
            public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
    
}
