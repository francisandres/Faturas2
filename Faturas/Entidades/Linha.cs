using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class Linha
    {
        [Key]
        public Guid? LinhaId { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        public decimal TotalLinha { get; set; }

       
        public virtual Fatura Fatura { get; set; }
        [ForeignKey("Fatura")]
        public Guid FaturaId { get; set; }

        
        public virtual Produto Produto { get; set; }
        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }


    }
}
