using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
    public class FuncionarioDTO
    {
        public string Primeiro_nome { get; set; }
        public string Ultimo_nome { get; set; }
        public string Email { get; set; }
        public string BilheteDeIdentidade { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public DateTime inicioDoContrato { get; set; }
    }
}
