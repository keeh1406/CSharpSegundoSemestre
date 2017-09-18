using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Produto
    {
        public long ProdutoId { get; set; }

        public string Name { get; set; }

        public string DescricaoProduto { get; set; }

        public DateTime DataValidade { get; set; }

        public string Marca { get; set; }

        public int LojaId { get; set; }
        public Loja Loja { get; set; }
    }
}