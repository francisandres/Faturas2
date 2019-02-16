using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class Fatura
    {
        [Key]
        public Guid? FaturaId { get; set; }

       
        public virtual Cliente Cliente { get; set; }
        
        public Guid ClienteId { get; set; }
        
        public string EstadodaFatura { get; set; }
        public string Nome { get; set; }

       
        public decimal TotalFatura { get; set; }
        public decimal ValorPago { get; set; }

        public  ICollection<Linha> Linha { get; set; }
    }
}
