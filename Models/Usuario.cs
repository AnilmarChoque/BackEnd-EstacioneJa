using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacioneJa.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacioneJa.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Senha { get; set; }
        public byte[]? SenhaHash { get; set; }
        public byte[]? SenhaSalt { get; set; }
        public Boolean Preferencia { get; set; }
        public long Cpf { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<VagaUsuario> VagaUsuarios { get; set; }
        public List<UsuarioPagamento> UsuarioPagamentos { get; set; }
    }
}