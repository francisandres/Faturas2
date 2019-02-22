using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
    public class LinhaDTO
    {
        public Guid linhaId { get; set; }
        public decimal precoVenda { get; set; }
        public int quantidade { get; set; }
        public decimal totalLinha { get; set; }
        public Guid faturaId { get; set; }
        public Guid produtoId { get; set; }


    }
}
