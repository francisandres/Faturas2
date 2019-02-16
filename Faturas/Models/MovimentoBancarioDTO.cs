using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Faturas.Models
{
    public class MovimentoBancarioDTO
    {
        public Guid MovimentoBancarioId { get; set; }
        public string TipodeMovimento { get; set; }
        public decimal ValorDoMovimento { get; set; }
        public Guid ContaBancariaId { get; set; }
        
    }
}