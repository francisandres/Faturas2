﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faturas.Models
{
    public class TipoDeReceitaDTO
    {
        public Guid tipoDeReceita { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
        public decimal preco { get; set; }
    }
}
