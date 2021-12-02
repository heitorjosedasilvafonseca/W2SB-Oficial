using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2SB.Models
{
    public class Proprietario
    {
        public long? ProprietarioId { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}