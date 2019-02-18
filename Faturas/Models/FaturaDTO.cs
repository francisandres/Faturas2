using Faturas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
    public class FaturaDTO
    {
        public Guid FaturaId { get; set; }
        public Guid ClienteId { get; set; }

        public string Nome { get; set; }
        public string EstadodaFatura { get; set; }
        public decimal TotalFatura { get; set; }
        public decimal ValorPago { get; set; }
        public ICollection<LinhaDTO> LinhaDTO { get; set; }
       
       
       
    }
}
