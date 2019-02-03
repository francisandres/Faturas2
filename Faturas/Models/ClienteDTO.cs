using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
   
        public class ClienteDTO
        {
            
       
            
            public Guid ClienteId { get; set; }
            public decimal Saldo { get; set; }
            public string Primeiro_nome { get; set; }
            public string Ultimo_nome { get; set; }
            public string Email { get; set; }
      
    }
    
}
