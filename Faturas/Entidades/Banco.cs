using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class Banco
    {
        [Key]
        public Guid? bancoId { get; set; }
        public string nomeDoBanco { get; set; }
        public string nomeDoGestor {get; set;}
        public string contactoDoGestor { get; set; }
        public string emailDoGestor { get; set; }
        public decimal saldo { get; set; }
       
        public ICollection<ContaBancaria>  ContaBancaria { get; set; }

        
    }
}