using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Venda
    {
        public long VendaId { get; set; }

        public string DescricaoVenda { get; set; }

        public int QuantidadeProduto { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVenda { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}