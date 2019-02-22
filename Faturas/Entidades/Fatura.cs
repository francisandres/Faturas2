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
        public Guid? faturaId { get; set; }

       
        public virtual Cliente cliente { get; set; }
        
        public Guid clienteId { get; set; }
        
        public string estadoDaFatura { get; set; }
        public string nome { get; set; }

       
        public decimal totalFatura { get; set; }
        public decimal valorPago { get; set; }

        public  ICollection<Linha> Linha { get; set; }
    }
}
