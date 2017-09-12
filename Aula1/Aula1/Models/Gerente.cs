﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Gerente
    {
        public long GerenteId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Endereco { get; set; }

        public long Telefone { get; set; }

        public string Email { get; set; }

        public long CPF { get; set; }
    }
}