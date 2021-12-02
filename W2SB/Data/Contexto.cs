using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace W2SB.Data
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=Contexto")
        {
        }

        public System.Data.Entity.DbSet<W2SB.Models.Proprietario> Proprietarios { get; set; }

        public System.Data.Entity.DbSet<W2SB.Models.Veiculo> Veiculoes { get; set; }
    }
}
