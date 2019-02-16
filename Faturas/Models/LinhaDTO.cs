using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
    public class LinhaDTO
    {
        public Guid LinhaId { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        public decimal TotalLinha { get; set; }
        public Guid FaturaId { get; set; }
        public Guid ProdutoId { get; set; }


    }
}
