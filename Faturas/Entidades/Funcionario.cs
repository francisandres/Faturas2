using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Entidades
{
    public class Funcionario
    {
        [Key]
        public Guid? FuncionarioId { get; set; }
        public string Primeiro_nome { get; set; }
        public string Ultimo_nome { get; set; }
        public string Email { get; set; }
        public string BilheteDeIdentidade { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public DateTime inicioDoContrato { get; set; }
        public virtual ICollection<Vencimento> Vencimentos { get; set; } 
    }
}
