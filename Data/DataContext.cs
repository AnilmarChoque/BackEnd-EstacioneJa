using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstacioneJa.Models;
using EstacioneJa.Utils;
using EstacioneJa.Models.Enuns;

namespace EstacioneJa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<OcupacaoVaga> OcupacaoVagas { get; set;}
        public DbSet<Pagamento> Pagamentos { get; set;}
        public DbSet<Sensor> Sensores { get; set;}
        public DbSet<Usuario> Usuarios{ get; set;}
        public DbSet<Vaga> Vagas { get; set;}
        public DbSet<VagaUsuario> VagaUsuarios{ get; set;}
        public DbSet<UsuarioPagamento> UsuarioPagamentos{ get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Usuario user = new Usuario();      
            Criptografia.CriarSenhaHash("123456", out byte[] hash, out byte[]salt);      
            user.Id = 1;
            user.Nome = "UsuarioAdmin";
            user.Senha = string.Empty; 
            user.SenhaHash = hash;
            user.SenhaSalt = salt;          
            user.Cpf = 12345678912;
            user.Email = "seuEmail@gmail.com";
            user.Preferencia = false;
            user.TipoUsuario = TipoUsuarioEnum.Cliente;

            modelBuilder.Entity<Usuario>().HasData(user); 

            modelBuilder.Entity<VagaUsuario>()
                .HasKey(vu => new {vu.VagaId, vu.UsuarioId});

            modelBuilder.Entity<UsuarioPagamento>()
                .HasKey(up => new {up.UsuarioId, up.PagamentoId});

            Vaga vaga = new Vaga();
            vaga.Id = 1;
            vaga.Disponibilidade = false;
            vaga.Andar = 1;
            vaga.Secao = "A2";
            vaga.Numero = 1;
            vaga.Preferencia = "Livre";
            vaga.Latitude = -23.5200241;
            vaga.Longitude = -46.596498;
            vaga.sensotId = 1;
        }

    }
}