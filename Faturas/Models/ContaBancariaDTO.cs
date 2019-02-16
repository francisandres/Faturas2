using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Faturas.Models
{
    public class ContaBancariaDTO
    {
        public Guid contaBancariaId { get; set; }
        public string numeroDeConta { get; set; }
        public string tipoDeConta { get; set; }
        public decimal saldo { get; set; }
        public Guid bancoId { get; set; }

        
    }
}