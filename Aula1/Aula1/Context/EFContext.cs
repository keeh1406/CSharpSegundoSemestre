using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aula1.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
    }
}