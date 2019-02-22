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
        public Guid clienteId { get; set; }

        public string nome { get; set; }
        public string estadoDaFatura { get; set; }
        public decimal totalFatura { get; set; }
        public decimal valorPago { get; set; }
        public ICollection<LinhaDTO> LinhaDTO { get; set; }
       
       
       
    }
}
