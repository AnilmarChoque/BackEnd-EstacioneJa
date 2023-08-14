using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacioneJa.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Emissor { get; set; }
        public string Receptor { get; set; }
        public string FormaPagamento { get; set; }
        public List<UsuarioPagamento> UsuarioPagamentos { get; set; }
    }
}