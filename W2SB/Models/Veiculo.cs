using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2SB.Models
{
    public class Veiculo
    {
        public long? VeiculoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
        public long? ProprietarioId { get; set; }
        public Proprietario proprietario { get; set; }
    }
}