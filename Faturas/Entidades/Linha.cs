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
        public Guid? linhaId { get; set; }
        public decimal precoVenda { get; set; }
        public int quantidade { get; set; }
        public decimal totalLinha { get; set; }

       
        public virtual Fatura fatura { get; set; }
        [ForeignKey("Fatura")]
        public Guid faturaId { get; set; }

        
        public virtual Produto produto { get; set; }
        [ForeignKey("Produto")]
        public Guid produtoId { get; set; }


    }
}
