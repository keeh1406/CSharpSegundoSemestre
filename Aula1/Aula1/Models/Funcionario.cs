﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Funcionario
    {
        public long FuncionarioId { get; set; }

        public string Name { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        public long Telefone { get; set; }

        public string Email { get; set; }

        public long CPF { get; set; }

        public Boolean Gerente { get; set; }

        public int LojaId { get; set; }
        public Loja Loja { get; set; }
    }
}