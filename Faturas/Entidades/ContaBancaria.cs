using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class ContaBancaria
    {
        [Key]
        public Guid? contaBancariaId { get; set; }
        public string numeroDeConta { get; set; }
        public decimal saldo { get; set; }
        public string tipoDeConta { get; set; }
        public Banco banco {get; set;}
        
        [ForeignKey("Banco")]
        public Guid? bancoId { get; set; }
        public ICollection<MovimentoBancario> movimentos { get; set; }
    }
}