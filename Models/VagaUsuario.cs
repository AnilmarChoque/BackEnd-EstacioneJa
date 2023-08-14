using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacioneJa.Models
{
    public class VagaUsuario
    {
        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}