using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class ReceitaOrcamento
    {
        [Key]
        public Guid? receitaId { get; set; }
        public string  nomeDaReceita { get; set; }
        public DateTime? data { get; set; }
        public string nomeDoArtigo { get; set; }
        public string nomeTipoReceita { get; set; }
        public int quantidade { get; set; }
        public decimal preco { get; set; }
    }
}
