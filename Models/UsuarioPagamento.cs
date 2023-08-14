using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacioneJa.Models
{
    public class UsuarioPagamento
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}